/*Auto create
Don't Edit it*/

using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine;

namespace F8Framework.F8ExcelDataClass
{
	[Serializable]
	public class LocalizedStringsItem
	{
		[Preserve]
		public System.Int32 id;
		[Preserve]
		public System.String TextID;
		[Preserve]
		public System.String ChineseSimplified;
		[Preserve]
		public System.String English;
	}
	
	[Serializable]
	public class LocalizedStrings
	{
		public Dictionary<System.Int32, LocalizedStringsItem> Dict = new Dictionary<System.Int32, LocalizedStringsItem>();
	}
}
