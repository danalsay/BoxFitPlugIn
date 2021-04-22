using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFitPlugIn
{
    class Sorting
    {
        //public static ProductBox[] boxes;

        public static ProductBox[] SortByWidth(ProductBox[] boxes)
        {                   
            var qry = from b in boxes orderby b.xUnitWidth select b;
            return  qry.ToArray();
        }

        public static ProductBox[] SortByHeight(ProductBox[] boxes)
        {
            var qry = from b in boxes orderby b.yUnitHeight select b;
            return qry.ToArray();
        }
    }
}
