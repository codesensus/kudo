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

namespace Kudo.Web.Infrastructure.Security
{
	/// <summary>
	/// An interface for customizing the format of password hashes.
	/// </summary>
	/// <remarks>
	/// The password hash algorithm SHOULD use a salt. If the algorithm uses
	/// a salt, this MUST be included in the returned hash to allow the
	/// verification method to read this value at a later point.
	/// </remarks>
	public interface IPasswordHashAlgorithm
	{
		/// <summary>
		/// Generates a hash given a plain text password.
		/// </summary>
		/// <param name="password">The password to hash</param>
		/// <returns>The hash</returns>
		string GenerateHash(string password);

		/// <summary>
		/// Verifies that the given plain text validates against the given
		/// hash.
		/// </summary>
		/// <param name="password">The password to verify</param>
		/// <param name="hash">The hash</param>
		/// <returns>true if the password is valid; otherwise, false</returns>
		bool VerifyPassword(string password, string hash);
	}
}