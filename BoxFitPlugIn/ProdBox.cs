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

    class ProductBox : IComparable<ProductBox>
    {
        public System.Drawing.Point[] ArrayPoints;
        public double xUnitWidth;
        public double yUnitHeight;
        public double Area;
        public System.Drawing.Point BasePoint;
        public Polygon BaseShape;
        public int ID;

        public ProductBox(System.Drawing.Point[] arrPoints)
        {
            ArrayPoints = arrPoints;
            xUnitWidth = this.ArrayPoints.Max<System.Drawing.Point>(x => x.X) - this.ArrayPoints.Min<System.Drawing.Point>(x => x.X);
            yUnitHeight = this.ArrayPoints.Max<System.Drawing.Point>(y => y.Y) - this.ArrayPoints.Min<System.Drawing.Point>(y => y.Y);
            Area = xUnitWidth * yUnitHeight;
            BaseShape = new Polygon();
            foreach (System.Drawing.Point p in arrPoints)
            {
                this.BaseShape.Points.Add(new System.Windows.Point(p.X, p.Y));
            }
        }

        /// <summary>
        /// implements CompareTo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ProductBox other)
        {
           return Area.CompareTo(other.Area);
        }

    }

}
