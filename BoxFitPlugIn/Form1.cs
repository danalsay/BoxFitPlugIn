using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxFitPlugIn
{
    public partial class Form1 : Form
    {  
        int pnlWidth = 220;
        int pnlHeight = 300;
        String SortType = "none";
        Panel myContainer = new Panel();
        Graphics G;
        ProductBox[] Boxes; 

       
        public Form1()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //MessageBox.Show(resources.GetString("Description"));
            //MessageBox.Show()
            string Message = "This module will attempt to fit the provided collection of 2 dimensional(irregular) shapes(polygons) as defined in the accompanying text file into a rectangular container in the most efficient arrangement to conserve space. {0}";
            Message += "You are asked to provide the dimensions of the container onto which the boxes will be packed.The algorithm that is being used is Binary Tree Sort with options for (pre) sorting optimization.";
            MessageBox.Show(String.Format(Message,Environment.NewLine));
            //MessageBox.Show(Message);
            InitializeComponent();
            txtWidth.Text = "220";
            txtHeight.Text = "360";
        }

        private void DrawProdBox(ProductBox ProdpBox)
        {
            Pen penpolygon = new Pen(Color.Black, 1);
            SolidBrush sb = new SolidBrush(Color.Pink);
            for (int i = 0; i < ProdpBox.ArrayPoints.Length; i++)
            {
                ProdpBox.ArrayPoints[i].X += ProdpBox.BasePoint.X;
                ProdpBox.ArrayPoints[i].Y += ProdpBox.BasePoint.Y;
            }
            
            G.FillPolygon(sb, ProdpBox.ArrayPoints);
            G.DrawPolygon(penpolygon, ProdpBox.ArrayPoints);
        }

        private void IntializeBoxes()
        {

            //Boxes = new ProductBox[] {
            //new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,20),new Point(60,20),new Point(60,40),new Point(20,40),new Point(20,60),new Point(0,60), new Point(0,20), new Point(20,20) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,40),new Point(60,40),new Point(60,60),new Point(0,60),new Point(0,40), new Point(20,40) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(40,0), new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40),new Point(20,20),new Point(0,20) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(40,0),new Point(40,40), new Point(20, 40), new Point(20,60),new Point(0,60), }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(40,0), new Point(40,80),new Point(20,80),new Point(20,20),new Point(0,20) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(60,0), new Point(60,40),new Point(20,40),new Point(20,20),new Point(0,20) }),
            //new ProductBox(new Point[] { new Point(40,0), new Point(60,0), new Point(60, 40), new Point(40,40),new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40),new Point(20,20),new Point(40,20) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,20),new Point(60,20),new Point(60,40),new Point(40,40),new Point(40,60),new Point(20,60),new Point(20,40),new Point(0,40),new Point(0,20),new Point(20,20) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(60,0), new Point(60,20),new Point(40,20),new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40) }),
            //new ProductBox(new Point[] { new Point(40,0), new Point(60,0), new Point(60,60),new Point(0,60),new Point(0,40),new Point(40,40) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,100),new Point(0,100) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,60),new Point(20,60),new Point(20,80),new Point(0,80),new Point(0,40),new Point(20,40) })
            //};
            Boxes = Util.TxtDataReader.LoadCsv("ShapePoints.txt");
        }


        private void AddContainer( int width, int height)
        {
            this.Controls.Remove(myContainer);
            myContainer.Width = width;
            myContainer.Height = height;
            myContainer.BorderStyle = BorderStyle.FixedSingle;
            myContainer.BackColor = Color.AntiqueWhite;
            this.Controls.Add(myContainer);
            myContainer.Location = new System.Drawing.Point(400, 80);
        }
       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.HightSort.Checked)
                SortType = "height";
            else if (WidthSort.Checked)
                SortType = "width";
            else if (FootPrintSort.Checked)
                SortType = "footprint";
            else if (none.Checked)
                SortType = "none";


            G = myContainer.CreateGraphics();
            try { pnlWidth = Convert.ToInt32(txtWidth.Text); }
            catch
            {
                MessageBox.Show("Please Enter a integer value for width: (100 - 1000) ");
            }
            try { pnlHeight = Convert.ToInt32(txtHeight.Text); }
            catch
            {
                MessageBox.Show("Please Enter a integer value for height: (100 - 1000) ");
            }
       
            AddContainer(pnlWidth , pnlHeight);
            StackBoxes();      
        }

        private void StackBoxes()
        {
            IntializeBoxes();
            //Array.Sort(Boxes);
            //Boxes = Sorting.SortByHeight(Boxes);
            switch (SortType)
            {
                case "width":
                    Boxes = Sorting.SortByWidth(Boxes);
                    break;
                case "height":
                    Boxes = Sorting.SortByHeight(Boxes);
                    break;
                case "footprint":
                    Array.Sort(Boxes);
                    Array.Reverse(Boxes);
                    break;
                case "none":
                    Boxes = Sorting.SortByOriginalOrder(Boxes);
                    break;
                default:                   
                    break;
            }

            Algorithm A = new Algorithm(Boxes, 0, 0, pnlWidth, pnlHeight);
            A.Fit(Boxes);
            for (int i = 0; i < Boxes.Length; i++)
            {
                DrawProdBox(Boxes[i]);
            }
        }



    }
}
