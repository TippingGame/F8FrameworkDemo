/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class itemItem
	{
		[Preserve]
		public System.Int32 id;
		[Preserve]
		public System.String name;
	}
	
	[Serializable]
	public class item
	{
		public Dictionary<System.Int32, itemItem> Dict = new Dictionary<System.Int32, itemItem>();
	}
}
