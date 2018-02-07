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

namespace Lab2
{
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
            foreach (Point p in this.coordinates)
            {
                String mystr = "(";
                mystr += (int)p.X;
                mystr += ", ";
                mystr += (int)p.Y;
                mystr += ")";
                g.FillEllipse(Brushes.Black, p.X - WIDTH / 2,
                    p.Y - WIDTH / 2, WIDTH, HEIGHT);
                g.DrawString(mystr, Font, Brushes.Black, p.X + WIDTH / 2,
                    p.Y - WIDTH / 2);
            };
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coordinates.Add(p);
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                this.coordinates.Clear();
                this.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }
    }
}
