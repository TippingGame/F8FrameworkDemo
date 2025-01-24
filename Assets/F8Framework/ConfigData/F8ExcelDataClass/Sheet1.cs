/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class Sheet1Item
	{
		[Preserve]
		public System.Int32 id;
		[Preserve]
		public System.String name;
		[Preserve]
		public System.Single[] price;
		[Preserve]
		public System.Int32 fddfd;
		[Preserve]
		public System.Single aaasd;
		[Preserve]
		public System.Int32[] dfdfd;
		[Preserve]
		public System.String[] gggaa;
	}
	
	[Serializable]
	public class Sheet1
	{
		public Dictionary<System.Int32, Sheet1Item> Dict = new Dictionary<System.Int32, Sheet1Item>();
	}
}
