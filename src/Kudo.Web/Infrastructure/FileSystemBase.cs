using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Kudo.Data;
// We need to map this explicitly, as we've also got a File in the System.IO
// namespace which we need to use
using FileNode = Kudo.Core.DomainModel.File;

namespace Kudo.Web.Infrastructure
{
	public abstract class FileSystemBase : IFileSystem
	{
		private static readonly Regex _idSplitter = new Regex("(.{1})(?:(.{3})){5}", RegexOptions.Compiled);

		protected virtual string GetFilePath(FileNode file, char separatorChar)
		{
			string folder = GetFolderPath(file, separatorChar);

			return string.Format("{0}" + separatorChar + "{1}", folder, file.Filename);
		}

		protected virtual string GetFolderPath(FileNode file, char separatorChar)
		{
			var hexadecimalId = file.Id.ToString("x16");

			// Divide the ID into portions, so each folder has no more than 16^3 files
			var idParts = _idSplitter.Match(hexadecimalId).Groups.Cast<Group>()
				.SelectMany(g => g.Captures.Cast<Capture>()).Skip(1)
				.Select(c => c.Value.TrimStart('0').PadLeft(1, '0')).ToArray();

			return string.Join(new string(separatorChar, 1), idParts);
		}

		public abstract void Delete(FileNode file);

		public abstract Stream Read(FileNode file);

		public abstract void Write(FileNode file, Stream input);

		public abstract Uri GetUrl(FileNode file);

		public abstract string ConvertToSafeFileName(string fileName);

		public abstract bool SupportsBothHttpAndHttps
		{
			get;
		}
	}
}