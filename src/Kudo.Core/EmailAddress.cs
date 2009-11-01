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

namespace Kudo.Core
{
	/// <summary>
	/// Represents an email address related to a user.
	/// </summary>
	public class EmailAddress : Entity
	{
		/// <summary>
		/// The user the email address belongs to.
		/// </summary>
		public virtual User User
		{
			get;
			set;
		}

		/// <summary>
		/// The value of the email address.
		/// </summary>
		public virtual string Value
		{
			get;
			set;
		}
	}
}