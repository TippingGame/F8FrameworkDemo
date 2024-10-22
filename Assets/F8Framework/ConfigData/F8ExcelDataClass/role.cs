/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class roleItem
	{
		[Preserve]
		public int id;
		[Preserve]
		public string name;
	}
	
	[Serializable]
	public class role
	{
		public Dictionary<int, roleItem> Dict = new Dictionary<int, roleItem>();
	}
}
