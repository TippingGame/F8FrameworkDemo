/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class roleItem
	{
	public int id;
	public string name;
	}
	
	[Serializable]
	public class role
	{
		public Dictionary<int, roleItem> Dict = new Dictionary<int, roleItem>();
	}
}
