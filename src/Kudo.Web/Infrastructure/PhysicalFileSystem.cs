﻿/**
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
using FileNode = Kudo.Core.DomainModel.File;

namespace Kudo.Web.Infrastructure
{
	public class PhysicalFileSystem : FileSystemBase
	{
		public override void Delete(FileNode file)
		{
			throw new NotImplementedException();
		}

		public override Stream Read(FileNode file)
		{
			throw new NotImplementedException();
		}

		public override void Write(FileNode file, Stream input)
		{
			throw new NotImplementedException();
		}

		public override Uri GetUrl(FileNode file)
		{
			throw new NotImplementedException();
		}

		public override string ConvertToSafeFileName(string fileName)
		{
			throw new NotImplementedException();
		}

		public override bool SupportsBothHttpAndHttps
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}