using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = $"{int.Parse(textBox1.Text) * 5}";
            }
            catch
            {
                textBox2.Text = "Error - Wrong input";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = $"{int.Parse(textBox1.Text) * 10}";
            }
            catch
            {
                textBox2.Text = "Error - Wrong input";
            }
        }
    }
}
