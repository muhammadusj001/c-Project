﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {

        }

         private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Login = new Form2();
            Login.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
