using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoxFitPlugIn
{
    /// <summary>
    /// Binary Tree Bin Packing
    /// </summary>
    class Algorithm
    {
        public ProductBox[] Blocks;
        public Node Root = new Node();

        public Algorithm(ProductBox[] PBs, double  xBase, double  yBase, double wd, double  ht)
        {
            Blocks = PBs;
            Root.x = xBase;
            Root.y = yBase;
            Root.h = ht;
            Root.w = wd;
            Root = new Node {w = wd, h = ht };
        }
        
        public void SortBoxesBySize()
        {
            this.Blocks.ToList().Sort((a, b) => a.xUnitWidth.CompareTo(b.xUnitWidth) ) ;
        }
               
        public void Fit(ProductBox[] Boxes)
        {
                for (int i = 0 ; i < Boxes.Length; i++)
                {
                    var node = FindNode(Root, Boxes[i].xUnitWidth, Boxes[i].yUnitHeight);
                    if (node != null)
                    {
                        var newNode = SplitNode(node, Boxes[i].xUnitWidth, Boxes[i].yUnitHeight);
                        Boxes[i].BasePoint.X = (int)newNode.x;
                        Boxes[i].BasePoint.Y = (int)newNode.y;
                    }

                }
           
        }

        /// <summary>
        /// This is the main workhorse logic for the fitting Algorithm. 
        /// It will attempt to place the box in the next available space in the node and return Next if successful
        /// otherwise return node so that the fitting method will split the rmaining space into the next sprites. 
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="boxWidth"></param>
        /// <param name="boxLength"></param>
        /// <returns></returns>
        private Node FindNode(Node rootNode, double boxWidth, double boxLength)
        {
            if (rootNode.used)
            {
                var nextNode = FindNode(rootNode.RightNode, boxWidth, boxLength);

                if (nextNode == null)
                {
                    nextNode = FindNode(rootNode.BottomNode, boxWidth, boxLength);
                }

                return nextNode;
            }
            else if (boxWidth <= rootNode.w && boxLength <= rootNode.h)
            {
                return rootNode;
            }
            else
            {
                return null;
            }
        }

        private Node SplitNode(Node node, double boxWidth, double boxLength)
        {
            node.used = true;
            node.BottomNode = new Node {  y = node.y + boxLength, x = node.x, h = node.h - boxLength, w = node.w };
            node.RightNode = new Node { y = node.y, x = node.x + boxWidth, h = boxLength, w = node.w - boxWidth };
            return node;
        }

        internal class Node
        {
            public Node RightNode;
            public Node BottomNode;
            public double x;
            public double  y;
            public double  h;
            public double  w;
            public bool used;
        }

    }
}
