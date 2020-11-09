using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace BoxFitPlugIn
{
    //class ProdBox
    //{
    //    List<Point>
    //}

    class ProductBox : IComparable<ProductBox>
    {

        List<BoxSquare> lstBox;
        public List<Point> PolyPoints;
        public Point[] ArrayPoints;
        public double xUnitWidth;
        public double yUnitHeight;
        public double Area;
        public Point BasePoint;
        


        public ProductBox(Point[] arrPoints)
        {
            ArrayPoints = arrPoints;
            xUnitWidth = this.ArrayPoints.Max<Point>(x => x.X) - this.ArrayPoints.Min<Point>(x => x.X);
            yUnitHeight = this.ArrayPoints.Max<Point>(y => y.Y) - this.ArrayPoints.Min<Point>(y => y.Y);
            Area = xUnitWidth * yUnitHeight;
        }


        /// <summary>
        /// implements CompareTo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ProductBox other)
        {
           //return xUnitWidth.CompareTo(other.xUnitWidth);
           return Area.CompareTo(other.Area);
        }

        ProductBox(List<BoxSquare> bList, double Width, double height)
        {
            lstBox = bList;
            xUnitWidth = GetMaxWidth();
            yUnitHeight = GetMaxHeight();
        }

        ProductBox(List<BoxSquare> bList)
        {
            lstBox = bList;
            xUnitWidth = GetMaxWidth();
            yUnitHeight = GetMaxHeight();
        }

        //Get Max Width
        private double GetMaxWidth()
        {
           return this.lstBox.Max<BoxSquare>(x => x.xStartPos) - this.lstBox.Min<BoxSquare>(x => x.xStartPos) + BoxSquare.SquareSide;
        }

        //GetMax height
        private double GetMaxHeight()
        {
            return this.lstBox.Max<BoxSquare>(y => y.yStartPos) - this.lstBox.Min<BoxSquare>(y => y.yStartPos) + BoxSquare.SquareSide;
        }


    }

    class BoxSquare
    {
        public const double SquareSide = 20;
        public double xStartPos;
        public double yStartPos;
        BoxSquare(double x, double y)
        {
            xStartPos = x;
            yStartPos = y;
        }

        public static void DrawBoxSquare(ContainerControl container, double xPos, double yPos)
        {
            Graphics g = container.CreateGraphics();
            Pen p = new Pen(Color.Black);
        }

    }


}
