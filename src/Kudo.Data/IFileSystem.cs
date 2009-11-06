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
using Kudo.Core.DomainModel;
using Stream = System.IO.Stream;

namespace Kudo.Data
{
	public interface IFileSystem
	{
		/// <summary>
		/// Removes a file from the file system.
		/// </summary>
		/// <param name="file">The file to remove the data stream for</param>
		void Delete(File file);

		/// <summary>
		/// Reads a file's data stream from the file system.
		/// </summary>
		/// <param name="file">The file to read the data stream for</param>
		/// <returns>The file's data stream</returns>
		Stream Read(File file);

		/// <summary>
		/// Writes a data stream to the file system.
		/// </summary>
		/// <param name="file">The file to write the data stream for</param>
		/// <param name="input">The file's data stream</param>
		void Write(File file, Stream input);

		/// <summary>
		/// Gets a URL for accessing the file's data stream over HTTP/HTTPS.
		/// </summary>
		/// <exception cref="System.NotSupportedException">
		/// Thrown when the file system doesn't know a public URL for the file's
		/// data stream
		/// </exception>
		/// <param name="file">The file to get the public URL for</param>
		/// <returns>The URL of the file's data stream</returns>
		Uri GetUrl(File file);

		/// <summary>
		/// Converts the file name to a safe version compatible with the underlying
		/// file system.
		/// </summary>
		/// <param name="fileName">The file name to protect from illegal characters</param>
		/// <returns>The safe file name</returns>
		string ConvertToSafeFileName(string fileName);

		/// <summary>
		/// Declares whether the URL retrieved for a file can be used with both the
		/// HTTP and the HTTPS protocol.
		/// </summary>
		bool SupportsBothHttpAndHttps
		{
			get;
		}
	}
}