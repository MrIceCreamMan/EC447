using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public class Mypoints
    {
        public Point p;
        public int color;
        public Mypoints() {
            color = 2;
        }
    }
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 10;
            const int HEIGHT = 10;
            Graphics g = e.Graphics;
            foreach (Mypoints myp in this.coordinates)
            {
                if (myp.color == 2)
                    g.FillEllipse(Brushes.Black, myp.p.X - WIDTH / 2,
                        myp.p.Y - WIDTH / 2, WIDTH, HEIGHT);
                else if (myp.color == 1)
                    g.FillEllipse(Brushes.Red, myp.p.X - WIDTH / 2,
                        myp.p.Y - WIDTH / 2, WIDTH, HEIGHT);
                else
                    g.FillEllipse(Brushes.Green, myp.p.X - WIDTH / 2,
                        myp.p.Y - WIDTH / 2, WIDTH, HEIGHT);
                
            };

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Mypoints myp = new Mypoints();
                myp.p.X = e.X;
                myp.p.Y = e.Y;
                this.coordinates.Add(myp);
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                int i = 0;
                while (i < this.coordinates.Count)
                {
                    Mypoints myp = (Mypoints)this.coordinates[i];
                    bool condition;
                    condition = (e.X > myp.p.X - 6) && (e.X < myp.p.X + 6);
                    condition = condition && (e.Y > myp.p.Y - 6) && (e.Y < myp.p.Y + 6);
                    if (condition)
                    {
                        if (myp.color == 1)
                        {
                            this.coordinates.RemoveAt(i);
                        }
                        else
                            i++;
                        myp.color--;
                    }
                    else
                        i++;
                }
                this.Invalidate();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }
    }
}
