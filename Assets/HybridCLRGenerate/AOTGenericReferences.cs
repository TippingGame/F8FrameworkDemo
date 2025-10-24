using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"F8Framework.Core.dll",
		"LitJson.dll",
		"System.Core.dll",
		"System.dll",
		"UnityEngine.CoreModule.dll",
		"UnityEngine.JSONSerializeModule.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// F8Framework.Core.AssetManager.<>c__DisplayClass30_0<object>
	// F8Framework.Core.AssetManager.<>c__DisplayClass30_1<object>
	// F8Framework.Core.AssetManager.<LoadAsyncCoroutine>d__31<object>
	// F8Framework.Core.OnAssetObject<object>
	// F8Framework.Core.ResourcesLoader.<>c__DisplayClass19_0<object>
	// F8Framework.Core.Singleton<object>
	// System.Action<int,object>
	// System.Action<int>
	// System.Action<object,object>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary.KeyCollection<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary.ValueCollection<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.Dictionary<byte,object>
	// System.Collections.Generic.Dictionary<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,byte>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<F8Framework.Core.TypeStringPair>
	// System.Collections.Generic.EqualityComparer<F8Framework.Core.UIConfig>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<F8Framework.Core.TypeStringPair,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,F8Framework.Core.UIConfig>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IDictionary<object,LitJson.ArrayMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.ObjectMetadata>
	// System.Collections.Generic.IDictionary<object,LitJson.PropertyMetadata>
	// System.Collections.Generic.IDictionary<object,object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<F8Framework.Core.TypeStringPair,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,F8Framework.Core.UIConfig>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<F8Framework.Core.TypeStringPair,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,F8Framework.Core.UIConfig>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<F8Framework.Core.TypeStringPair>
	// System.Collections.Generic.IEqualityComparer<byte>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<F8Framework.Core.TypeStringPair,object>
	// System.Collections.Generic.KeyValuePair<byte,object>
	// System.Collections.Generic.KeyValuePair<int,F8Framework.Core.UIConfig>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,byte>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.LinkedList.Enumerator<int>
	// System.Collections.Generic.LinkedList<int>
	// System.Collections.Generic.LinkedListNode<int>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<F8Framework.Core.TypeStringPair>
	// System.Collections.Generic.ObjectEqualityComparer<F8Framework.Core.UIConfig>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.Func<UnityEngine.Vector4,int>
	// System.Nullable<UnityEngine.Vector2>
	// System.Nullable<UnityEngine.Vector3>
	// System.Nullable<byte>
	// System.Predicate<int>
	// System.Predicate<object>
	// }}

	public void RefMethods()
	{
		// object F8Framework.Core.AssetBundleManager.GetAssetObject<object>(string,string,string,F8Framework.Core.AssetBundleLoader&)
		// object F8Framework.Core.AssetManager.GetAssetObject<object>(string,string,F8Framework.Core.AssetManager.AssetAccessMode)
		// object F8Framework.Core.AssetManager.Load<object>(string,string,F8Framework.Core.AssetManager.AssetAccessMode)
		// F8Framework.Core.BaseLoader F8Framework.Core.AssetManager.LoadAsync<object>(string,F8Framework.Core.OnAssetObject<object>,string,F8Framework.Core.AssetManager.AssetAccessMode)
		// System.Collections.IEnumerator F8Framework.Core.AssetManager.LoadAsyncCoroutine<object>(string,string,F8Framework.Core.AssetManager.AssetAccessMode)
		// System.Void F8Framework.Core.IFSM<object>.ChangeState<object>()
		// System.Void F8Framework.Core.MessageManager.AddEventListener<int>(int,System.Action,object)
		// System.Void F8Framework.Core.MessageManager.DispatchEvent<int>(int)
		// System.Void F8Framework.Core.MessageManager.RemoveEventListener<int>(int,System.Action,object)
		// System.Void F8Framework.Core.ProcedureManager.RunProcedureNode<object>()
		// object F8Framework.Core.ResourcesLoader.Load<object>()
		// System.Void F8Framework.Core.ResourcesLoader.LoadAsync<object>(F8Framework.Core.OnAssetObject<object>)
		// object F8Framework.Core.ResourcesManager.GetAssetObject<object>(string,string,F8Framework.Core.ResourcesLoader&)
		// object F8Framework.Core.ResourcesManager.Load<object>(string)
		// object F8Framework.Core.ResourcesManager.LoadAll<object>(string,string,F8Framework.Core.ResourcesLoader&,bool)
		// F8Framework.Core.ResourcesLoader F8Framework.Core.ResourcesManager.LoadAsync<object>(string,F8Framework.Core.OnAssetObject<object>)
		// object F8Framework.Core.StaticModule.GetInstance<object>()
		// System.Void F8Framework.Core.StorageManager.SetObject<object>(string,object,bool)
		// System.Void F8Framework.Core.UIManager.Initialize<int>(System.Collections.Generic.Dictionary<int,F8Framework.Core.UIConfig>)
		// F8Framework.Core.UILoader F8Framework.Core.UIManager.OpenAsync<int>(int,object[],F8Framework.Core.UICallbacks)
		// object F8Framework.Core.Util.LitJson.ToObject<object>(string)
		// object LitJson.JsonMapper.ToObject<object>(string)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.JsonUtility.FromJson<object>(string)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Vector3,UnityEngine.Quaternion)
		// object UnityEngine.Resources.Load<object>(string)
		// UnityEngine.ResourceRequest UnityEngine.Resources.LoadAsync<object>(string)
	}
}