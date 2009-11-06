using System;
using System.IO;
using Kudo.Data;
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