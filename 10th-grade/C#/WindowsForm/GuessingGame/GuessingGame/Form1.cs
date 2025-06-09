using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        int rand_num = GetRandNum();
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            if (num > rand_num)
            {
                label4.Text = "Your guess is too high";
            }
            else if (num < rand_num)
            {
                label4.Text = "Your guess is too low";
            }
            else if (num == rand_num)
            {
                label4.Text = "You are correct!";
            }
        }
        static int GetRandNum()
        {
            Random rand = new Random();
            int rand_num = rand.Next(1, 21);
            return rand_num;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}
