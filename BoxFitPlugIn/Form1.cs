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
        int pnlWidth = 100;
        int pnlHeight = 600;
        Panel myContainer = new Panel();
        Graphics G;
        ProductBox[] Boxes; 
        //    = {
        //    new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(10,20),new Point(10,30),new Point(0,30), new Point(0,10), new Point(10,10) }),
        //    new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,20),new Point(30,20),new Point(30,30),new Point(0,30),new Point(0,20), new Point(10,20) }),
        //    new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
        //    new ProductBox(new Point[] { new Point(0,0), new Point(0,10), new Point(20,10),new Point(20,20),new Point(20,30), new Point(10, 30), new Point(10,40),new Point(0,40), }),
        //    new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,40),new Point(10,40),new Point(10,10),new Point(0,10) }),
        //    new ProductBox(new Point[] { new Point(0,0), new Point(30,0), new Point(30,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
        //    new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30, 20), new Point(20,20),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(20,10) }),
        //    new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(20,20),new Point(20,30),new Point(10,30),new Point(10,20),new Point(0,20),new Point(0,10),new Point(10,10) }),
        //    new ProductBox(new Point[] { new Point(10,0), new Point(30,0), new Point(30,10),new Point(20,10),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20) }),
        //    new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30,30),new Point(0,30),new Point(0,20),new Point(20,20) }),
        //    new ProductBox(new Point[] { new Point(0,0), new Point(10,0), new Point(10,50),new Point(0,50) }),
        //    new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,30),new Point(10,30),new Point(10,40),new Point(0,40),new Point(0,20),new Point(10,20) })
        //};

        public Form1()
        {
            InitializeComponent();   

        }

        private void DrawProdBox(ProductBox ProdpBox)
        {

            Pen penpolygon = new Pen(Color.Black, 1);
            for (int i = 0; i < ProdpBox.ArrayPoints.Length; i++)
            {
                ProdpBox.ArrayPoints[i].X += ProdpBox.BasePoint.X;
                ProdpBox.ArrayPoints[i].Y += ProdpBox.BasePoint.Y;
            }

            G.DrawPolygon(penpolygon, ProdpBox.ArrayPoints); 

        }

        private void IntializeBoxes()
        {
            Boxes = new ProductBox[] {
            new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(10,20),new Point(10,30),new Point(0,30), new Point(0,10), new Point(10,10) }),
            new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,20),new Point(30,20),new Point(30,30),new Point(0,30),new Point(0,20), new Point(10,20) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(0,10), new Point(20,10),new Point(20,20),new Point(20,30), new Point(10, 30), new Point(10,40),new Point(0,40), }),
            new ProductBox(new Point[] { new Point(0,0), new Point(20,0), new Point(20,40),new Point(10,40),new Point(10,10),new Point(0,10) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(30,0), new Point(30,20),new Point(10,20),new Point(10,10),new Point(0,10) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30, 20), new Point(20,20),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20),new Point(10,10),new Point(20,10) }),
            new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,10),new Point(30,10),new Point(30,20),new Point(20,20),new Point(20,30),new Point(10,30),new Point(10,20),new Point(0,20),new Point(0,10),new Point(10,10) }),
            new ProductBox(new Point[] { new Point(10,0), new Point(30,0), new Point(30,10),new Point(20,10),new Point(20,30),new Point(0,30),new Point(0,20),new Point(10,20) }),
            new ProductBox(new Point[] { new Point(20,0), new Point(30,0), new Point(30,30),new Point(0,30),new Point(0,20),new Point(20,20) }),
            new ProductBox(new Point[] { new Point(0,0), new Point(10,0), new Point(10,50),new Point(0,50) }),
            new ProductBox(new Point[] { new Point(10,0), new Point(20,0), new Point(20,30),new Point(10,30),new Point(10,40),new Point(0,40),new Point(0,20),new Point(10,20) })
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
            myContainer.Location = new System.Drawing.Point(20, 120);

        }
       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try { pnlWidth = Convert.ToInt32(txtWidth.Text); }
            catch { }
            try { pnlHeight = Convert.ToInt32(txtHeight.Text); }
            catch { }
       
            AddContainer(pnlWidth , pnlHeight);
            G = myContainer.CreateGraphics();
            StackBoxes();      
        }

        private void StackBoxes()
        {
            IntializeBoxes();
            Algorithm A = new Algorithm(Boxes, 0, 0, pnlWidth, pnlHeight);
            Array.Sort(A.Blocks);
            A.Fit(A.Blocks);
            for (int i = 0; i < A.Blocks.Length; i++)
            {
                DrawProdBox(A.Blocks[i]);
            }

        }

        private void LoadBox(int x, int y, System.Drawing.Bitmap bm)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new System.Drawing.Size(20, 20);
            pic.Location = new System.Drawing.Point(x, y);
            myContainer.Controls.Add(pic);
        }

    }
}
