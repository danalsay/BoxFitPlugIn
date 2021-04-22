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
        String SortType = "default";
        Panel myContainer = new Panel();
        Graphics G;
        ProductBox[] Boxes; 

       
        public Form1()
        {

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
            //new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(10,20),new Point(10,30),new Point(0,30), new Point(0,10), new Point(10,10) }),
            //new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,20),new Point(30,20),new Point(30,30),new Point(0,30),new Point(0,20), new Point(10,20) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(0,10), new Point(20,10),new Point(20,20),new Point(20,30), new Point(10, 30), new Point(10,40),new Point(0,40), }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,40),new Point(10,40),new Point(10,10),new Point(0,10) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(30,0), new Point(30,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30, 20), new Point(20,20),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(20,10) }),
            //new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(20,20),new Point(20,30),new Point(10,30),new Point(10,20),new Point(0,20),new Point(0,10),new Point(10,10) }),
            //new ProductBox(new Point[] { new Point(10,0), new Point(30,0), new Point(30,10),new Point(20,10),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20) }),
            //new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30,30),new Point(0,30),new Point(0,20),new Point(20,20) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(10,0), new Point(10,50),new Point(0,50) }),
            //new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,30),new Point(10,30),new Point(10,40),new Point(0,40),new Point(0,20),new Point(10,20) })
            //};

            Boxes = new ProductBox[] {
            new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,20),new Point(60,20),new Point(60,40),new Point(20,40),new Point(20,60),new Point(0,60), new Point(0,20), new Point(20,20) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,40),new Point(60,40),new Point(60,60),new Point(0,60),new Point(0,40), new Point(20,40) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(40,0), new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40),new Point(20,20),new Point(0,20) }),
            //new ProductBox(new Point[] { new Point(0,0), new Point(0,20), new Point(40,20),new Point(40,40),new Point(40,60), new Point(20, 60), new Point(20,80),new Point(0,80), }),
            new ProductBox(new Point[] { new Point(0,0), new Point(40,0),new Point(40,40), new Point(20, 40), new Point(20,60),new Point(0,60), }),
            new ProductBox(new Point[] { new Point(0,0), new Point(40,0), new Point(40,80),new Point(20,80),new Point(20,20),new Point(0,20) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(60,0), new Point(60,40),new Point(20,40),new Point(20,20),new Point(0,20) }),
            new ProductBox(new Point[] { new Point(40,0), new Point(60,0), new Point(60, 40), new Point(40,40),new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40),new Point(20,20),new Point(40,20) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,20),new Point(60,20),new Point(60,40),new Point(40,40),new Point(40,60),new Point(20,60),new Point(20,40),new Point(0,40),new Point(0,20),new Point(20,20) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(60,0), new Point(60,20),new Point(40,20),new Point(40,60),new Point(0,60),new Point(0,40),new Point(20,40) }),
            new ProductBox(new Point[] { new Point(40,0), new Point(60,0), new Point(60,60),new Point(0,60),new Point(0,40),new Point(40,40) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,100),new Point(0,100) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(40,0), new Point(40,60),new Point(20,60),new Point(20,80),new Point(0,80),new Point(0,40),new Point(20,40) })
            };
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


            G = myContainer.CreateGraphics();
            try { pnlWidth = Convert.ToInt32(txtWidth.Text); }
            catch
            {
                this.G.FillRectangle(SystemBrushes.InactiveCaption, 100, 20, 260, 50);
                this.G.DrawString("Please Enter a integer value for width:", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
            }
            try { pnlHeight = Convert.ToInt32(txtHeight.Text); }
            catch
            {
                this.G.FillRectangle(SystemBrushes.InactiveCaption, 100, 80, 260, 50);
                this.G.DrawString("Please Enter a integer value for height:", this.Font, SystemBrushes.ActiveCaptionText, 20, 20);
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
                    break;
                default:                   
                    break;
            }

            Algorithm A = new Algorithm(Boxes, 0, 0, pnlWidth, pnlHeight);
            //Array.Sort(A.Blocks);
            A.Fit(Boxes);
            for (int i = 0; i < Boxes.Length; i++)
            {
                DrawProdBox(Boxes[i]);
            }
        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void LoadBox(int x, int y, System.Drawing.Bitmap bm)
        //{
        //    PictureBox pic = new PictureBox();
        //    pic.Size = new System.Drawing.Size(20, 20);
        //    pic.Location = new System.Drawing.Point(x, y);
        //    myContainer.Controls.Add(pic);
        //}

    }
}
