using System;
using System.IO;
using Kudo.Data;
using FileNode = Kudo.Core.DomainModel.File;

namespace Kudo.Web.Infrastructure
{
	public abstract class FileSystemBase : IFileSystem
	{
		public void Delete(FileNode file)
		{
			throw new NotImplementedException();
		}

		public Stream Read(FileNode file)
		{
			throw new NotImplementedException();
		}

		public void Write(FileNode file, Stream input)
		{
			throw new NotImplementedException();
		}

		public Uri GetUrl(FileNode file)
		{
			throw new NotImplementedException();
		}

		public string ConvertToSafeFileName(string fileName)
		{
			throw new NotImplementedException();
		}

		public bool SupportsBothHttpAndHttps
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}