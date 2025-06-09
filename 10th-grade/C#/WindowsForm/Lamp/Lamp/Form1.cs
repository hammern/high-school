using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lamp
{
    public partial class Form1 : Form
    {
        bool Lamp_ON = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lamp_ON = !Lamp_ON;
            if (Lamp_ON)
            {
                pictureBox1.ImageLocation = "C:\\Users\\Nadav\\School\\כיתה י\\C#\\WindowsForm\\Lamp\\Lamp_On.gif";
            }
            else
            {
                pictureBox1.ImageLocation = "C:\\Users\\Nadav\\School\\כיתה י\\C#\\WindowsForm\\Lamp\\Lamp_Off.gif";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Lamp_ON = !Lamp_ON;
            if (Lamp_ON)
            {
                pictureBox1.ImageLocation = "C:\\Users\\Nadav\\School\\כיתה י\\C#\\WindowsForm\\Lamp\\Lamp_On.gif";
            }
            else
            {
                pictureBox1.ImageLocation = "C:\\Users\\Nadav\\School\\כיתה י\\C#\\WindowsForm\\Lamp\\Lamp_Off.gif";
            }
        }
    }
}
