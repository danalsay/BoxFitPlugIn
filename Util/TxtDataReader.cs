using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace BoxFitPlugIn.Util
{
    class TxtDataReader
    {
        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.


        public static ProductBox[] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = 12; //lines[0].Split(',').Length;

            // Allocate the data array.
            //string[,] values = new string[num_rows, num_cols];
            ProductBox[] Shapes = new ProductBox[12];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                Point[] points = new Point[line_r.Length];

                for (int c = 0; c < line_r.Length; c++)
                {
                    try
                    {
                        string[] point = line_r[c].Split(',');
                        points[c] = new Point(Convert.ToInt32(point[0]), Convert.ToInt32(point[1]));
                    }
                    catch
                    {
                        continue;
                    }
                }

                Shapes[r] = new ProductBox(points);
                Shapes[r].ID = r + 1;
            }

            // Return the values.
            return Shapes;
        }
    }
}
