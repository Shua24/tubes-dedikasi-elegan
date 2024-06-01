﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVAnalytics;

namespace StatForm
{
    public partial class DokterUI2 : Form
    {
        private string dirReference;

        public DokterUI2(string dirReference)
        {
            InitializeComponent();
            this.dirReference = dirReference;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Debug.Assert(!string.IsNullOrEmpty(input));
            CSVTable tab = new CSVTable(dirReference, string.Empty);

            if (!string.IsNullOrEmpty(tab.ColError)) 
            { 
                label3.Text = tab.ColError; 
            }
            
            List<(object, object)> list = tab.CsvStats(input);

            if (listBox1.Items.Count != 0) 
            { 
                listBox1.Items.Clear(); 
            }

            foreach (var item in list)
            {
                string displayItem = $"{item.Item1}% - {item.Item2}";
                listBox1.Items.Add(displayItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login(dirReference);
            login.Show();
        }
    }
}
