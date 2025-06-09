using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Text = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
            textBox3.Text = Text.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Text = int.Parse(textBox1.Text) - int.Parse(textBox2.Text);
            textBox3.Text = Text.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Text = int.Parse(textBox1.Text) * int.Parse(textBox2.Text);
            textBox3.Text = Text.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
            {
                string Text = "Math Error";
                textBox3.Text = Text;
            }
            else
            {
                double Text = double.Parse(textBox1.Text) / double.Parse(textBox2.Text);
                textBox3.Text = Text.ToString();
            }
        }
    }
}
