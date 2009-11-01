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
	/// <summary>
	/// Defines an unsalted password hash algorithm using generics to allow
	/// the same class to be reused for multiple algorithms.
	/// </summary>
	/// <remarks>
	/// This class only serves as a reference implementation and to use with
	/// legacy systems where passwords are already hashed without a salt.
	/// </remarks>
	/// <typeparam name="T">The type of the hash algorithm</typeparam>
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
			return string.Equals(GenerateHash(password), hash, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}