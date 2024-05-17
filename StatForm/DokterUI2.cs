using System;
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
        public DokterUI2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string input = textBox1.Text;
            Debug.Assert(input != null || input != string.Empty);

            //CSVTable tab = new CSVTable(directory, string.Empty);
            //List<(object, object)> list = tab.CsvStats(input);

            if (listBox1.Items.Count != 0) listBox1.Items.Clear();

            //foreach (var item in list)
            {
            //    string displayItem = $"{item.Item1}% - {item.Item2}";
            //    listBox1.Items.Add(displayItem);
            }
        }
    }
}
