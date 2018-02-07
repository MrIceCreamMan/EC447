using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private string otFileName;
        private string userKey;

        public Form1()
        {
            InitializeComponent();
            otFileName = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog SourceFile = new OpenFileDialog();
            SourceFile.FileName = "OpenFileDialog1";
            SourceFile.Filter = "All files (*.*)|*.*|Encrypted files (*.enc)|*.enc";
            if (SourceFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = SourceFile.FileName;
                otFileName = SourceFile.FileName + ".enc";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otFileName = textBox1.Text + ".enc";
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                userKey = textBox2.Text;

            if (File.Exists(otFileName))
            {
                DialogResult rst = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                byte[] byte_array = File.ReadAllBytes(textBox1.Text);
                for (int i = 0; i < byte_array.Length; i++)
                {
                    int keyidx = i % userKey.Length;
                    byte_array[i] = (byte)(byte_array[i] ^ userKey[keyidx]);
                }
                try
                {
                    File.WriteAllBytes(otFileName, byte_array);
                }
                catch
                {
                    MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Operation completed successfully");
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            otFileName = textBox1.Text;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                userKey = textBox2.Text;

            // .enc file has 4 at least characters
            if (otFileName.Length < 4)
            {
                MessageBox.Show("Not a .enc file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idx = 0;
            string first_half = ""; string second_half = "";
            for (int i = 0; i < otFileName.Length - 4; i++)
            {
                first_half += otFileName[idx];
                idx++;
            }
            for (int j = 0; j < 4; j++)
            {
                second_half += otFileName[idx];
                idx++;
            }
            if (second_half != ".enc")
            {
                MessageBox.Show("Not a .enc file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(first_half))
            {
                DialogResult rst = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                byte[] byte_array = File.ReadAllBytes(otFileName);
                for (int i = 0; i < byte_array.Length; i++)
                {
                    int keyidx = i % userKey.Length;
                    byte_array[i] = (byte)(byte_array[i] ^ userKey[keyidx]);
                }
                try
                {
                    File.WriteAllBytes(first_half, byte_array);
                }
                catch
                {
                    MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Operation completed successfully");
            return;
        }
    }
}
