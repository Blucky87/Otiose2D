﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonoGame.Tools.Pipeline
{
    public partial class TextEditDialog : Form
    {
        public string text = "";

        public TextEditDialog(string title, string label, string text)
        {
            InitializeComponent();

            this.Text = title;
            label1.Text = label;
            textBox1.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
