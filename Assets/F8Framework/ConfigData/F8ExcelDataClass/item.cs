/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class itemItem
	{
		[Preserve]
		public int id;
		[Preserve]
		public string name;
	}
	
	[Serializable]
	public class item
	{
		public Dictionary<int, itemItem> Dict = new Dictionary<int, itemItem>();
	}
}
