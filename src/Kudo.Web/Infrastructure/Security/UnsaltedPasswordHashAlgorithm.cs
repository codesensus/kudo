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
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kudo.Web.Infrastructure.Security
{
	public class UnsaltedPasswordHashAlgorithm<T> : IPasswordHashAlgorithm
		where T : HashAlgorithm, new()
	{
		public string GenerateHash(string password)
		{
			using (HashAlgorithm hashAlgorithm = new T())
			{
				byte[] passwordBytes = Encoding.Default.GetBytes(password);
				byte[] hashBytes = hashAlgorithm.ComputeHash(passwordBytes);

				var hash = hashBytes.Select(b => b.ToString("x2")).ToArray();

				return string.Join("", hash);
			}
		}

		public bool VerifyPassword(string password, string hash)
		{
			throw new NotImplementedException();
		}
	}
}