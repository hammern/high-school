using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateAverage
{
    public partial class Form1 : Form
    {
        double All = 0;
        double Count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            All += double.Parse(textBox1.Text);
            Count += 1;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Avg = All / Count;
            label3.Text += Avg.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            All = 0;
            Count = 0;
            label3.Text = "The average is: ";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
