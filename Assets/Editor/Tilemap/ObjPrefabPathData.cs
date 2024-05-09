using Demo;
using UnityEngine;

namespace DemoEditor
{
    public class ObjPrefabPathData
    {
        public GameObject obj;
        private ObjPrefabData quadTreeObjPrefabPath;
        public string objPrefabPath
        {
            get
            {
                return quadTreeObjPrefabPath.prefabPath;
            }
            set
            {
                quadTreeObjPrefabPath.prefabPath = value;
            }
        }
        public Vector3 objModelSize
        {
            get
            {
                return quadTreeObjPrefabPath.modelSize;
            }
            set
            {
                quadTreeObjPrefabPath.modelSize = value;
            }
        }
        
        public ObjPrefabPathData(GameObject obj)
        {
            this.obj = obj;
            quadTreeObjPrefabPath = obj.GetComponent<ObjPrefabData>();
            if (quadTreeObjPrefabPath == null)
                quadTreeObjPrefabPath = obj.AddComponent<ObjPrefabData>();
            quadTreeObjPrefabPath.prefabPath = obj.name;
                
        }
    }
}