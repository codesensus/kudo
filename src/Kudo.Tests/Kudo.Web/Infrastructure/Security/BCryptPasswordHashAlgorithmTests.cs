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

using Kudo.Web.Infrastructure.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Kudo.Web.Infrastructure.Security
{
	[TestClass]
	public class BCryptPasswordHashAlgorithmTests
	{
		[TestMethod]
		public void CanGenerateBCryptHash()
		{
			var hasher = new BCryptPasswordHashAlgorithm();
			string hash = hasher.GenerateHash("test");
			Assert.IsNotNull(hash);
		}

		[TestMethod]
		public void CanValidateBCryptHash()
		{
			var hasher = new BCryptPasswordHashAlgorithm();
			bool valid = hasher.VerifyPassword("test", "$2a$10$sB2bgbgkW48LJQETILGquOUciQQUjgzGWUjeAOsPzhLdLl3109C7i");
			Assert.IsTrue(valid);
		}

		[TestMethod]
		public void CanValidateGeneratedBCryptHash()
		{
			var hasher = new BCryptPasswordHashAlgorithm();
			string hash = hasher.GenerateHash("test");
			bool valid = hasher.VerifyPassword("test", hash);
			Assert.IsTrue(valid);
		}
	}
}