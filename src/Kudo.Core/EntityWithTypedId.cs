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

namespace Kudo.Core
{
	public abstract class EntityWithTypedId<T>
	{
		protected EntityWithTypedId()
		{
			CreatedOn = DateTime.Now;
		}

		/// <summary>
		/// The identifier of the entity.
		/// </summary>
		public virtual T Id
		{
			get;
			protected set;
		}

		/// <summary>
		/// The date and time when the entity was created.
		/// </summary>
		/// <remarks>
		/// This value SHOULD be persisted with time zone;
		/// alternatively, in UTC.
		/// </remarks>
		public virtual DateTime CreatedOn
		{
			get;
			set;
		}

		/// <summary>
		/// The user who created the entity.
		/// </summary>
		public virtual User CreatedBy
		{
			get;
			set;
		}

		/// <summary>
		/// The date and time when the entity was last modified;
		/// null, if the entity isn't modified.
		/// </summary>
		/// <remarks>
		/// This value SHOULD be persisted with time zone;
		/// alternatively, in UTC.
		/// </remarks>
		public virtual DateTime? ModifiedOn
		{
			get;
			set;
		}

		/// <summary>
		/// The user who has last modified the entity.
		/// </summary>
		public virtual User ModifiedBy
		{
			get;
			set;
		}

		/// <summary>
		/// The date and time when the entity was deleted;
		/// null, if the entity isn't deleted.
		/// </summary>
		/// <remarks>
		/// This value SHOULD be persisted with time zone;
		/// alternatively, in UTC.
		/// </remarks>
		public virtual DateTime? DeletedOn
		{
			get;
			set;
		}

		/// <summary>
		/// The user who deleted the entity.
		/// </summary>
		public virtual User DeletedBy
		{
			get;
			set;
		}
	}
}