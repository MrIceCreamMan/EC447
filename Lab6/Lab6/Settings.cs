using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Settings : Form
    {
        private int Pencolor;
        private int Fillcolor;
        private int Penwidth;
        private bool Fill;
        private bool Outline;

        public Settings()
        {
            InitializeComponent();
        }

        public Settings(bool inFill, bool inOutline, int inPencolor, int inFillcolor, int inPenwidth)
        {
            InitializeComponent();
            Fill = inFill;
            checkBox1.Checked = inFill;

            Outline = inOutline;
            checkBox2.Checked = inOutline;

            Pencolor = inPencolor;
            listBox1.SelectedIndex = inPencolor;

            Fillcolor = inFillcolor;
            listBox2.SelectedIndex = inFillcolor;

            Penwidth = inPenwidth;
            listBox3.SelectedIndex = inPenwidth;
        }

        public int getPC() { return Pencolor; }
        public int getFC() { return Fillcolor; }
        public int getPW() { return Penwidth; }
        public bool getFill() { return Fill; }
        public bool getOutl() { return Outline; }

        private void button1_Click(object sender, EventArgs e)
        {
            Fill = checkBox1.Checked;
            Outline = checkBox2.Checked;
            Pencolor = listBox1.SelectedIndex;
            Fillcolor = listBox2.SelectedIndex;
            Penwidth = listBox3.SelectedIndex;
        }
    }
}
