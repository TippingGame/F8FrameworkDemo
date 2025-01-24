/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class roleItem
	{
		[Preserve]
		public System.Int32 id;
		[Preserve]
		public System.String name;
	}
	
	[Serializable]
	public class role
	{
		public Dictionary<System.Int32, roleItem> Dict = new Dictionary<System.Int32, roleItem>();
	}
}
