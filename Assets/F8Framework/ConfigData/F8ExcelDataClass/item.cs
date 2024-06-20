/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class itemItem
	{
	public int id;
	public string name;
	}
	
	[Serializable]
	public class item
	{
		public Dictionary<int, itemItem> Dict = new Dictionary<int, itemItem>();
	}
}
