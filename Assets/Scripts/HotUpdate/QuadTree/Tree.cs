using UnityEngine;

namespace Demo
{
    public class Tree : INode
    {
        public Bounds bound { get; set; }
        private Node root;
        public int maxDepth { get; }
        public int maxChildCount { get; }
        
        public bool Is2D = false;
        public Tree(Bounds bound,bool is2d)
        {
            this.bound = bound;
            this.maxDepth = 7;
            this.maxChildCount = 4;
            this.Is2D = is2d;
            root = new Node(bound, 0, this,is2d);
        }

        public void InsertObjData(ObjData obj)
        {
            root.InsertObjData(obj);
        }

        public void Inside(Camera camera)
        {
            root.Inside(camera);
        }

        public void Outside(Camera camera)
        {
            root.Outside(camera);
        }

        public void DrawBound()
        {
            root.DrawBound();
        }
    }
}