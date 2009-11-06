using System;
using System.IO;
using Kudo.Data;
// We need to map this explicitly, as we've also got a File in the System.IO
// namespace which we need to use
using FileNode = Kudo.Core.DomainModel.File;

namespace Kudo.Web.Infrastructure
{
	public abstract class FileSystemBase : IFileSystem
	{
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