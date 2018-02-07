using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font myfont = new Font("Arial", 25, FontStyle.Regular);
            string str1 = "Enter a starting integer (0-1,000,000,000):";
            string str2 = "Enter count (1-100):";
            string str3 = "Find Numeric Palindromes";
            g.DrawString(str1, Font, Brushes.Black, 137, 108);
            g.DrawString(str2, Font, Brushes.Black, 492, 108);
            g.DrawString(str3, myfont, Brushes.Black, 182, 34);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> pal_list = new List<int>();
            int x = 0;
            int y = 0;
            if (textBox1.Text.Length > 10 || textBox1.Text.Length <= 0 || textBox2.Text.Length > 3 || textBox2.Text.Length <= 0) {
                listBox1.DataSource = pal_list;
                label1.Text = "Please enter a positive integer within range.";
                return;
            }
            for (int i = 0; i < textBox1.Text.Length; i++) {
                if (textBox1.Text[i] < '0' || textBox1.Text[i] > '9') {
                    listBox1.DataSource = pal_list;
                    label1.Text = "Please enter a positive integer within range.";
                    return;
                }
            }
            for (int j = 0; j < textBox2.Text.Length; j++) {
                if (textBox2.Text[j] < '0' || textBox2.Text[j] > '9') {
                    listBox1.DataSource = pal_list;
                    label1.Text = "Please enter a positive integer within range.";
                    return;
                }
            }

            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);
            if (x > 1000000000 || y > 100)
            {
                listBox1.DataSource = pal_list;
                label1.Text = "Please enter a positive integer within range.";
                return;
            }
            label1.Text = "";
            int c = 0;
            while (c < y)
            {
                int flag = 1;
                string check = x.ToString();
                for (int k = 0; k < check.Length; k++)
                {
                    if (check[k] != check[check.Length - k - 1])
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    pal_list.Add(x);
                    c++;
                }
                x++;
            }
            listBox1.DataSource = pal_list;
        }
    }
}
