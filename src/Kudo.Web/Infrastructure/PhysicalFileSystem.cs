/**
 * Copyright 2004-2009 Codesensus
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;
// We need to map this explicitly, as we've also got a File in the System.IO
// namespace which we need to use
using FileNode = Kudo.Core.DomainModel.File;

namespace Kudo.Web.Infrastructure
{
	public class PhysicalFileSystem : FileSystemBase
	{
		protected override string GetFolderPath(FileNode file, char separatorChar)
		{
			string folder = GetFolderPath(file, separatorChar);

			return string.Format("{0}" + separatorChar + "{1}", "media", folder);
		}

		/// <remarks>
		/// This helper is only relevant as we translate paths using
		/// HostingEnvironment.MapPath. If we were talking directly to the file
		/// system Path.DirectorySeparatorChar should be used.
		/// </remarks>
		private string GetFilePath(FileNode file)
		{
			return GetFilePath(file, '/');
		}

		/// <remarks>
		/// This helper is only relevant as we translate paths using
		/// HostingEnvironment.MapPath. If we were talking directly to the file
		/// system Path.DirectorySeparatorChar should be used.
		/// </remarks>
		private string GetFolderPath(FileNode file)
		{
			return GetFolderPath(file, '/');
		}

		protected virtual string MapPath(string virtualPath)
		{
			return HostingEnvironment.MapPath(virtualPath);
		}

		public override void Delete(FileNode file)
		{
			string folderPath = MapPath(GetFolderPath(file));
			if (Directory.Exists(folderPath))
			{
				Directory.Delete(folderPath, true);
			}
		}

		public override Stream Read(FileNode file)
		{
			string filePath = MapPath(GetFilePath(file));

			return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		}

		public override void Write(FileNode file, Stream input)
		{
			string folderPath = MapPath(GetFolderPath(file));

			Directory.CreateDirectory(folderPath);

			string filePath = MapPath(GetFilePath(file));

			using (FileStream output = File.Create(filePath))
			{
				CopyStream(input, output);
			}
		}

		public override Uri GetUrl(FileNode file)
		{
			return new Uri(string.Format("/{0}", GetFilePath(file, '/')), UriKind.Relative);
		}

		public override string ConvertToSafeFileName(string fileName)
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

			var safeFileNameChars = (from c in fileName
									 where !invalidFileNameChars.Contains(c)
									 select c).ToArray();

			return new string(safeFileNameChars);
		}

		public override bool SupportsBothHttpAndHttps
		{
			get
			{
				return true;
			}
		}

		private static void CopyStream(Stream source, Stream destination)
		{
			var buffer = new byte[32768];
			int read;
			while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
			{
				destination.Write(buffer, 0, read);
			}
		}
	}
}