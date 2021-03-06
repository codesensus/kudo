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

using System.Security.Cryptography;
using Kudo.Web.Infrastructure.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Kudo.Web.Infrastructure.Security
{
	[TestClass]
	public class UnsaltedPasswordHashAlgorithmTests
	{
		[TestMethod]
		public void CanGenerateCorrectMd5Hash()
		{
			var hasher = new UnsaltedPasswordHashAlgorithm<MD5CryptoServiceProvider>();
			string hash = hasher.GenerateHash("test");
			Assert.AreEqual("098f6bcd4621d373cade4e832627b4f6", hash);
		}

		[TestMethod]
		public void CanVerifyCorrectMd5Hash()
		{
			var hasher = new UnsaltedPasswordHashAlgorithm<MD5CryptoServiceProvider>();
			bool valid = hasher.VerifyPassword("test", "098f6bcd4621d373cade4e832627b4f6");
			Assert.IsTrue(valid);
		}

		[TestMethod]
		public void CanGenerateCorrectSha1Hash()
		{
			var hasher = new UnsaltedPasswordHashAlgorithm<SHA1Managed>();
			string hash = hasher.GenerateHash("test");
			Assert.AreEqual("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3", hash);
		}

		[TestMethod]
		public void CanVerifyCorrectSha1Hash()
		{
			var hasher = new UnsaltedPasswordHashAlgorithm<SHA1Managed>();
			bool valid = hasher.VerifyPassword("test", "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3");
			Assert.IsTrue(valid);
		}
	}
}