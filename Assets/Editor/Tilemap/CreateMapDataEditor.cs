using System.Collections.Generic;
using System.IO;
using Demo;
using F8Framework.Core;
using UnityEditor;
using UnityEngine;

namespace DemoEditor
{
    public class CreateMapDataEditor : Editor
    {
        private static List<ObjPrefabPathData> selectGameObjectDatas = new List<ObjPrefabPathData>();

        public static void AllFillModelSizes()
        {
            for (int i = 0; i < selectGameObjectDatas.Count; i++)
            {
                if (selectGameObjectDatas[i].obj.transform.childCount == 0)
                {
                    if (selectGameObjectDatas[i].obj.GetComponent<MeshFilter>() != null &&
                        selectGameObjectDatas[i].obj.GetComponent<MeshFilter>().sharedMesh != null)
                    {
                        selectGameObjectDatas[i].objModelSize = selectGameObjectDatas[i].obj.GetComponent<MeshFilter>()
                            .sharedMesh.bounds.size;
                        continue;
                    }

                    if (selectGameObjectDatas[i].obj.GetComponent<SpriteRenderer>() != null)
                    {
                        selectGameObjectDatas[i].objModelSize =
                            selectGameObjectDatas[i].obj.GetComponent<SpriteRenderer>().bounds.size;
                    }
                }
            }
        }

        public static void AllFillPrefabPaths()
        {
            for (int i = 0; i < selectGameObjectDatas.Count; i++)
            {
                if (string.IsNullOrEmpty(selectGameObjectDatas[i].objPrefabPath))
                    continue;
                selectGameObjectDatas[i].objPrefabPath = selectGameObjectDatas[i].obj.name;
            }
        }
        
        public static void AddGameObjectDatas(List<GameObject> gameObjects)
        {
            selectGameObjectDatas.Clear();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].activeSelf == false)
                    continue;
                bool isRepeat = false;
                foreach (var item in selectGameObjectDatas)
                {
                    if (gameObjects[i] == item.obj)
                    {
                        isRepeat = true;
                        break;
                    }
                }

                if (isRepeat)
                {
                    LogF8.Log("有选择重复物体，已跳过该物体：" + gameObjects[i].name);
                    continue;
                }

                selectGameObjectDatas.Add(new ObjPrefabPathData(gameObjects[i]));
            }
        }

        private static string mapDataPath = "Assets/AssetBundles/MapData/QuadTreeData.json";
        private static bool mapDataPrefabPathSimple = false; //生成出的地图数据 是否预设路径简写，若简写 则仅用名称
        private static ObjDataContainer objDataContainer;
        private Vector2 previewMapDataScrollPosition;
        private static string mapData = "";
        public static void PreviewMapData()
        {
            objDataContainer = new ObjDataContainer();
            objDataContainer.objDatas = new ObjData[selectGameObjectDatas.Count];
            if (mapDataPrefabPathSimple)
            {
                for (int i = 0; i < selectGameObjectDatas.Count; i++)
                {
                    ObjData objData = new ObjData(selectGameObjectDatas[i].objPrefabPath,
                        selectGameObjectDatas[i].obj.transform.position,
                        selectGameObjectDatas[i].obj.transform.rotation,
                        selectGameObjectDatas[i].obj.transform.localScale,
                        selectGameObjectDatas[i].objModelSize,
                        i);
                    objDataContainer.objDatas[i] = objData;
                }
            }
            else
            {
                for (int i = 0; i < selectGameObjectDatas.Count; i++)
                {
                    ObjData objData = new ObjData(selectGameObjectDatas[i].objPrefabPath,
                        selectGameObjectDatas[i].obj.transform.position,
                        selectGameObjectDatas[i].obj.transform.rotation,
                        selectGameObjectDatas[i].obj.transform.localScale,
                        selectGameObjectDatas[i].objModelSize,
                        i);
                    objDataContainer.objDatas[i] = objData;
                }
            }
            mapData = Util.LitJson.ToJson(objDataContainer);
        }
        
        public static void CreateMapData()
        {
            TextWriter tw = new StreamWriter(mapDataPath, false);
            tw.Write(mapData);
            tw.Close();
            LogF8.Log("生成地图数据完成 path:" + mapDataPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}