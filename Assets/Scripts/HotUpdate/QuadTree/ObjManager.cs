using System;
using System.Collections;
using System.Collections.Generic;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine;

namespace Demo
{
    public enum SceneObjStatus
    {
        Loading,    //加载中
        Loaded      //加载完毕
    }

    public class SceneObjData
    {
        public ObjData objData;
        public SceneObjStatus status;
        public GameObject obj;

        public SceneObjData(ObjData objData)
        {
            this.objData = objData;
            this.obj = null;
        }
    }

    public class ObjManager : MonoBehaviour
    {
        public static ObjManager Instance;
        private Dictionary<int, SceneObjData> activeSceneObjDatas = new Dictionary<int, SceneObjData>();
        private List<int> unloadUids = new List<int>();
        
        public Bounds bounds;
        private Tree tree;

        public Camera cam;

        private ObjData[] jsonDatas;

        public GameObject player;
        
        private void Awake()
        {
            Instance = this;
        }

        IEnumerator Start()
        {
            player.SetActive(true);

            yield return FF8.Asset.LoadAsync<PoolsPreset>("PoolsPreset");
            FF8.GameObjectPool.InstallPools(FF8.Asset.GetAssetObject<PoolsPreset>("PoolsPreset"));
            
            tree = new Tree(bounds, true);
            yield return FF8.Asset.LoadAsync<TextAsset>("QuadTreeData");
            string jsonStr = FF8.Asset.GetAssetObject<TextAsset>("QuadTreeData").text;
            jsonDatas = JsonUtility.FromJson<ObjDataContainer>(jsonStr).objDatas;
            for (int i = 0; i < jsonDatas.Length; i++)
            {
                jsonDatas[i].uid = i;
                ObjData objData = new ObjData(jsonDatas[i].resPath, jsonDatas[i].pos, jsonDatas[i].rot, jsonDatas[i].scale, jsonDatas[i].size,jsonDatas[i].uid);
                tree.InsertObjData(objData);
            }
        }

        private void Update()
        {
            tree?.Inside(cam);
        }
        
        private void OnDrawGizmos()
        {
            if (tree != null)
            {
                tree.DrawBound();
            }
            else
            {
                Gizmos.DrawWireCube(bounds.center, bounds.size);
            }
        }
        
        public void LoadAsync(ObjData objData)
        {
            if (activeSceneObjDatas.ContainsKey(objData.uid))
            {
                return;
            }
            LoadObj(objData);
        }

        public void Unload(int uid)
        {
            if (activeSceneObjDatas.ContainsKey(uid) && unloadUids.Contains(uid) == false)
            {
                unloadUids.Add(uid);
            }
            for (int i = 0; i < unloadUids.Count; i++)
            {
                if (activeSceneObjDatas[unloadUids[i]].status == SceneObjStatus.Loaded)
                {
                    FF8.GameObjectPool.Despawn(activeSceneObjDatas[unloadUids[i]].obj);
                    activeSceneObjDatas.Remove(unloadUids[i]);
                    unloadUids.RemoveAt(i--);
                }
            }
        }

        private void LoadObj(ObjData obj)
        {
            SceneObjData sceneObjData = new SceneObjData(obj);
            sceneObjData.status = SceneObjStatus.Loading;
            activeSceneObjDatas.Add(obj.uid, sceneObjData);

            sceneObjData.status = SceneObjStatus.Loaded;
            SetObjTransfrom(obj.resPath, sceneObjData);
        }

        private void SetObjTransfrom(string prefabName, SceneObjData sceneObj)
        {
            sceneObj.obj = FF8.GameObjectPool.Spawn(prefabName);
            sceneObj.obj.transform.SetParent(transform);
            sceneObj.obj.transform.position = sceneObj.objData.pos;
            sceneObj.obj.transform.rotation = sceneObj.objData.rot;
            sceneObj.obj.transform.localScale = sceneObj.objData.scale;
        }
    }

}