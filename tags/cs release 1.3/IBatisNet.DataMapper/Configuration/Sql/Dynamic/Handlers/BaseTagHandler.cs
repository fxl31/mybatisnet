
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: $
 * $Date: $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

#region Imports
using System;
using System.Text;

using IBatisNet.DataMapper.Configuration.Sql.Dynamic.Elements;
#endregion

namespace IBatisNet.DataMapper.Configuration.Sql.Dynamic.Handlers
{
	/// <summary>
	/// Description r�sum�e de BaseTagHandler.
	/// </summary>
	public abstract class BaseTagHandler : ISqlTagHandler
	{

		#region Const
		/// <summary>
		/// BODY TAG
		/// </summary>
		public const int SKIP_BODY = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int INCLUDE_BODY = 1;
		/// <summary>
		/// 
		/// </summary>
		public const int REPEAT_BODY = 2;
		#endregion

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <returns></returns>
		public virtual int DoStartFragment(SqlTagContext ctx, SqlTag tag, object parameterObject) 
		{
			return BaseTagHandler.INCLUDE_BODY;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <param name="bodyContent"></param>
		/// <returns></returns>
		public virtual int DoEndFragment(SqlTagContext ctx, SqlTag tag, object parameterObject, StringBuilder bodyContent) 
		{
			return BaseTagHandler.INCLUDE_BODY;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="tag"></param>
		/// <param name="parameterObject"></param>
		/// <param name="bodyContent"></param>
		public virtual void DoPrepend(SqlTagContext ctx, SqlTag tag, object parameterObject, StringBuilder bodyContent) 
		{
			if (tag.IsPrependAvailable) 
			{
				if (bodyContent.ToString().Trim().Length > 0) 
				{
					if (ctx.IsOverridePrepend && tag == ctx.FirstNonDynamicTagWithPrepend) 
					{
						ctx.IsOverridePrepend = false;
					} 
					else 
					{
						bodyContent.Insert(0, tag.Prepend);
					}
				} 
				else 
				{
					if (ctx.FirstNonDynamicTagWithPrepend != null) 
					{
						ctx.FirstNonDynamicTagWithPrepend = null;
						ctx.IsOverridePrepend =true;
					}
				}
			}
		}

		
		#region ISqlTagHandler Menbers

		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsPostParseRequired
		{
			get
			{
				return false;
			}
		}


		#endregion
		#endregion

	}
}