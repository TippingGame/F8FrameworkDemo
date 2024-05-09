using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Demo
{
    [RequireComponent(typeof(Tilemap))]
    public class TilemapBehaviour : MonoBehaviour
    {
        private Tilemap tileMap;

        public Tilemap Tilemap
        {
            get
            {
                if (tileMap == null)
                    tileMap = GetComponent<Tilemap>();
                return tileMap;
            }
        }

        public List<GameObject> objectList;
        public Transform GeneratePoint;
        public int TilemapScope;
    }
}