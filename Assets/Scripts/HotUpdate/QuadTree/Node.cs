﻿using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class Node : INode
    {
        public Bounds bound { get; set; }

        private int depth;
        private Tree belongTree;
        private Node[] childList;
        private List<ObjData> objDataList;
        private bool isInside = false;
        private bool is2D = false;
        public Node(Bounds bound, int depth, Tree belongTree,bool is2d)
        {
            this.belongTree = belongTree;
            this.bound = bound;
            this.depth = depth;
            this.is2D = is2d;
            objDataList = new List<ObjData>();
        }

        public void InsertObjData(ObjData objData)
        {
            Node node = null;
            bool bChild = false;

            if (depth < belongTree.maxDepth && childList == null)
            {
                CreateChild();
            }
            if (childList != null)
            {
                for (int i = 0; i < childList.Length; ++i)
                {
                    Node item = childList[i];
                    
                    if (item.bound.Intersects(objData.GetObjBounds()))
                    {
                        node = item;
                        bChild = true;
                        break;
                    }
                }
            }
            //只有一个子节点，则放入子节点里
            if (bChild)
            {
                node.InsertObjData(objData);
            }
            else
            {
                objDataList.Add(objData);
            }
        }

        //在该节点里
        public void Inside(Camera camera)
        {
            //刷新子节点
            if (childList != null)
            {
                for (int i = 0; i < childList.Length; ++i)
                {
                    if (childList[i].bound.CheckBoundIsInCamera(camera))
                    {
                        childList[i].Inside(camera);
                    }
                    else
                    {
                        childList[i].Outside(camera);
                    }
                }
            }

            if (isInside)
                return;
            isInside = true;
            for (int i = 0; i < objDataList.Count; ++i)
            {
                ObjManager.Instance.LoadAsync(objDataList[i]);
            }

        }

        //不在该节点里
        public void Outside(Camera camera)
        {
            //刷新子节点
            if (childList != null)
            {
                for (int i = 0; i < childList.Length; ++i)
                {
                    childList[i].Outside(camera);
                }
            }
            if (isInside == false)
                return;
            isInside = false;
            for (int i = 0; i < objDataList.Count; i++)
            {
                ObjManager.Instance.Unload(objDataList[i].uid);
            }
        }

        private void CreateChild()
        {
            childList = new Node[belongTree.maxChildCount];
            int index = 0;
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    Vector3 centerOffset = new Vector3(bound.size.x / 4 * i, is2D ? bound.size.y / 4 * j : 0, is2D ? 0 : bound.size.z / 4 * j );
                    Vector3 cSize = new Vector3(bound.size.x / 2, is2D ? bound.size.y / 2 : bound.size.y,is2D ? bound.size.z : bound.size.z /2);
                    Bounds cBound = new Bounds(bound.center + centerOffset, cSize);
                    childList[index++] = new Node(cBound, depth + 1, belongTree,is2D);
                }
            }
        }

        public void DrawBound()
        {
            if (isInside)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(bound.center, bound.size);
            }
            else if (objDataList.Count != 0)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(bound.center, bound.size);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(bound.center, bound.size);
            }

            if (childList != null)
            {
                for (int i = 0; i < childList.Length; ++i)
                {
                    childList[i].DrawBound();
                }
            }
        }
    }
}