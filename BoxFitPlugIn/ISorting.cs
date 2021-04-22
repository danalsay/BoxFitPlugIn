using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFitPlugIn
{
    interface ISorting
    {
        void Sort() ; 
    }

    public class SortByWidth : ISorting
    {
        ProductBox[] boxes;
        SortByWidth(ProductBox[] Boxes) 
        {
            boxes = Boxes;
        }

        public void Sort() 
        {
            //Array.Sort<ProductBox>(boxes );
            var qry = from b in boxes orderby b.xUnitWidth select b;
            qry.ToArray();
        }
    }

}
