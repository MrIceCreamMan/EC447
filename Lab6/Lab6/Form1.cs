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

namespace Lab6
{
    public partial class Form1 : Form
    {
        private int Pencolor;
        private int Fillcolor;
        private int Penwidth;
        private bool Fill;
        private bool Outline;
        private ArrayList MyInputObjects = new ArrayList();
        private Point prePoint;
        private bool click_num;

        private string debugstr = "Welcome";
        public Form1()
        {
            InitializeComponent();
            Pencolor = 0;
            Fillcolor = 0;
            Penwidth = 0;
            Fill = false;
            Outline = true;
            this.radioButton1.Checked = true;
            click_num = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyInputObjects.Clear();
            this.Refresh();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyInputObjects.Count > 0)
                MyInputObjects.RemoveAt(MyInputObjects.Count - 1);
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings mysettings = new Settings(Fill, Outline, Pencolor, Fillcolor, Penwidth);
            mysettings.StartPosition = FormStartPosition.CenterParent;
            if (mysettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                debugstr = "ok";
                Fill = mysettings.getFill();
                Outline = mysettings.getOutl();
                Pencolor = mysettings.getPC();
                Fillcolor = mysettings.getFC();
                Penwidth = mysettings.getPW();
            }
            else
            {
                debugstr = "cancel";
            }
            this.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel2.CreateGraphics();
            
            foreach(MyDrawObject currObject in MyInputObjects)
            {
                currObject.Drawself(g);
            }
            
            //Font myfont = new Font("Arial", 30, FontStyle.Bold);
            //g.DrawString(debugstr, myfont, Brushes.Black, 100, 200);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            panel2_Paint(sender, e);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Point currPoint = new Point(e.X, e.Y);
            if (click_num == false)
            {
                prePoint = currPoint;
                click_num = true;
                return;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    if (Fill == false && Outline == false) MessageBox.Show("Fill and or outline must be checked.");
                    MyRectangle newrect = new MyRectangle(prePoint, currPoint, Pencolor, Penwidth + 1, Fillcolor, Fill, Outline);
                    MyInputObjects.Add(newrect);
                }
                else if (radioButton3.Checked)
                {
                    if (Fill == false && Outline == false) MessageBox.Show("Fill and or outline must be checked.");
                    MyEllipse newellp = new MyEllipse(prePoint, currPoint, Pencolor, Penwidth + 1, Fillcolor, Fill, Outline);
                    MyInputObjects.Add(newellp);
                }
                else
                {
                    MyLine newline = new MyLine(prePoint, currPoint, Pencolor, Penwidth + 1);
                    MyInputObjects.Add(newline);
                }
                click_num = false;
                this.Refresh();
                return;
            }
        }
    }
}
