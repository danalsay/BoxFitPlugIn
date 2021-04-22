using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;



namespace BoxFitPlugIn
{
    //class ProdBox
    //{
    //    List<Point>
    //}

    class ProductBox : IComparable<ProductBox>
    {
        //List<BoxSquare> lstBox;
        //public List<Point> PolyPoints;
        public System.Drawing.Point[] ArrayPoints;
        public double xUnitWidth;
        public double yUnitHeight;
        public double Area;
        public System.Drawing.Point BasePoint;
        public Polygon BaseShape;
        public PointCollection PC;
        //public IEnumerable<System.Windows.Point> iPoints;

        public ProductBox(System.Drawing.Point[] arrPoints)
        {
            ArrayPoints = arrPoints;
            xUnitWidth = this.ArrayPoints.Max<System.Drawing.Point>(x => x.X) - this.ArrayPoints.Min<System.Drawing.Point>(x => x.X);
            yUnitHeight = this.ArrayPoints.Max<System.Drawing.Point>(y => y.Y) - this.ArrayPoints.Min<System.Drawing.Point>(y => y.Y);
            Area = xUnitWidth * yUnitHeight;
            BaseShape = new Polygon();
            //iPoints = arrPoints.Cast<System.Windows.Point>();
            //BaseShape.Points = new PointCollection(iPoints);
            foreach (System.Drawing.Point p in arrPoints)
            {
                this.BaseShape.Points.Add(new System.Windows.Point(p.X, p.Y));
            }
        }

        //public ProductBox(IEnumerable<System.Windows.Point> points)
        //{
        //    BaseShape = new Polygon();
        //    BaseShape.Points = new PointCollection(points);
        //    //BaseShape.Points = points;
        //}


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

        //ProductBox(List<BoxSquare> bList, double Width, double height)
        //{
        //    lstBox = bList;
        //    xUnitWidth = GetMaxWidth();
        //    yUnitHeight = GetMaxHeight();
        //}

        //ProductBox(List<BoxSquare> bList)
        //{
        //    lstBox = bList;
        //    xUnitWidth = GetMaxWidth();
        //    yUnitHeight = GetMaxHeight();
        //}

        //Get Max Width
        //private double GetMaxWidth()
        //{
        //   return this.lstBox.Max<BoxSquare>(x => x.xStartPos) - this.lstBox.Min<BoxSquare>(x => x.xStartPos) + BoxSquare.SquareSide;
        //}

        //GetMax height
        //private double GetMaxHeight()
        //{
        //    return this.lstBox.Max<BoxSquare>(y => y.yStartPos) - this.lstBox.Min<BoxSquare>(y => y.yStartPos) + BoxSquare.SquareSide;
        //}

    }

    //class BoxSquare
    //{
    //    public const double SquareSide = 20;
    //    public double xStartPos;
    //    public double yStartPos;
    //    BoxSquare(double x, double y)
    //    {
    //        xStartPos = x;
    //        yStartPos = y;
    //    }

    //    //public static void DrawBoxSquare(ContainerControl container, double xPos, double yPos)
    //    //{
    //    //    Graphics g = container.CreateGraphics();
    //    //    System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Black);
    //    //}

    //}


}
