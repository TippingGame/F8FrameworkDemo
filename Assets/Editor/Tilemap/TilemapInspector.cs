using System.Collections.Generic;
using Demo;
using F8Framework.Core;
using UnityEngine;
using UnityEditor;

namespace DemoEditor
{
    public class MapDataClass
    {
        public string name;
        public Vector3 pos;
    }

    [CustomEditor(typeof(TilemapBehaviour))]
    [CanEditMultipleObjects]
    public class TilemapInspector : Editor
    {
        private TilemapBehaviour tilemapBehaviour;
        
        private Dictionary<string, MapDataClass> data = new Dictionary<string, MapDataClass>();
        
        public override void OnInspectorGUI()
        {
            tilemapBehaviour = (TilemapBehaviour)target;
            base.OnInspectorGUI();
            if (GUILayout.Button("导出地图生成物体"))
            {
                ExportMap();
            }

            if (GUILayout.Button("数据保存"))
            {
                SaveData();
            }

            // if (GUILayout.Button("销毁物体"))
            // {
            //     DestroyObject();
            // }
            //
            // if (GUILayout.Button("清理TileMap"))
            // {
            //     ClearMap();
            // }
        }
        
        public void ExportMap()
        {
            int tilecount = 0;

            data.Clear();
            
            for (int i = -tilemapBehaviour.TilemapScope; i < tilemapBehaviour.TilemapScope; i++)
            {
                for (int j = -tilemapBehaviour.TilemapScope; j < tilemapBehaviour.TilemapScope; j++)
                {
                    Vector3Int tempVec = new Vector3Int(i, j, 0);
                    if (tilemapBehaviour.Tilemap.GetTile(tempVec) == null)
                        continue;

                    MapDataClass mdc = new MapDataClass();
                    mdc.name = tilemapBehaviour.Tilemap.GetTile(tempVec).name;
                    mdc.pos = tilemapBehaviour.Tilemap.GetCellCenterWorld(tempVec);
                    data.Add(i + "_" + j, mdc);

                    tilecount++;
                }
            }
            
            LogF8.Log(string.Format("Tilemap范围：{0}，Tilemap名称：{1}，总共Tile数量：{2}",tilemapBehaviour.TilemapScope, tilemapBehaviour.Tilemap.name, tilecount.ToString()));
            LogF8.Log("导出地图数据完成");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            int count = 0;
            foreach (var value in data)
            {
                GameObject sp = tilemapBehaviour.objectList[0];
                for (int i = 0; i < tilemapBehaviour.objectList.Count; i++)
                {
                    if (tilemapBehaviour.objectList[i].name == value.Value.name)
                    {
                        sp = tilemapBehaviour.objectList[i];
                        GameObject go = Instantiate(sp, value.Value.pos, Quaternion.identity,
                            tilemapBehaviour.GeneratePoint.transform);
                        go.name = value.Value.name;
                        count += 1;
                    }
                }
            }
            LogF8.Log("生成物体完成_数量：" + count);
        }
        
        public void SaveData()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            //生成数据
            List<GameObject> gos = new List<GameObject>();
            for (int i = tilemapBehaviour.GeneratePoint.transform.childCount; i > 0; i--)
            {
                gos.Add(tilemapBehaviour.GeneratePoint.transform.GetChild(i - 1).gameObject);
            }
            CreateMapDataEditor.AddGameObjectDatas(gos);
            CreateMapDataEditor.AllFillModelSizes();
            CreateMapDataEditor.AllFillPrefabPaths();
            CreateMapDataEditor.PreviewMapData();
            CreateMapDataEditor.CreateMapData();
            
            DestroyObject();
        }
        
        public void DestroyObject()
        {
            for (int i = tilemapBehaviour.GeneratePoint.transform.childCount; i > 0; i--)
            {
                DestroyImmediate(tilemapBehaviour.GeneratePoint.transform.GetChild(i - 1).gameObject);
            }

            LogF8.Log("销毁物体完成");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public void ClearMap()
        {
            tilemapBehaviour.Tilemap.ClearAllTiles();
        }
    }
}