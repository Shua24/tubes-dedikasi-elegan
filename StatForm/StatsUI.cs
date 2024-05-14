using CSVAnalytics;
using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StatForm
{
    public partial class StatsUI : Form
    {
        public string directory; // supaya dokter gabisa update, Directory di-pass ke form dokter

        public StatsUI()
        {
            InitializeComponent();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private DataTable ToDataTable(DataFrame dataFrame)
        {
            DataTable dt = new DataTable();

            foreach (var col in dataFrame.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (var row in dataFrame.Rows)
            {
                var values = new object[dataFrame.Columns.Count];
                for (int i = 0; i < dataFrame.Columns.Count; i++)
                {
                    values[i] = row[i];
                }

                dt.Rows.Add(values);
            }

            return dt;
        }

        private void FillNA(DataFrame df)
        {
            for (int i = 0; i < df.Rows.Count; i++)
            {
                var row = df.Rows[i];
                for (int j = 0; j < df.Columns.Count; j++)
                {
                    var column = df.Columns[j];
                    var dataType = column.DataType;
                    if (row[j] == null)
                    {
                        if (dataType == typeof(int))
                        {
                            row[j] = 0;
                        }
                        else if (dataType == typeof(float))
                        {
                            row[j] = 0.0f;
                        }
                        else if (dataType == typeof(double))
                        {
                            row[j] = 0.0;
                        }
                        else if (dataType == typeof(decimal))
                        {
                            row[j] = 0.0m;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv) | *.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataFrame df = DataFrame.LoadCsv(ofd.FileName);
                    FillNA(df);

                    DataTable dt = ToDataTable(df);
                    Table.DataSource = dt;

                    string filepath = ofd.FileName;
                    directory = filepath;

                    label4.Text += " " + directory;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string input = textBox1.Text;
            Debug.Assert(input != null || input != string.Empty);

            CSVTable tab = new CSVTable(directory, string.Empty);
            List<(object, object)> list = tab.CsvStats(input);

            if (listBox1.Items.Count != 0) listBox1.Items.Clear();

            foreach (var item in list)
            {
                string displayItem = $"{item.Item1}% - {item.Item2}";
                listBox1.Items.Add(displayItem);
            }
        }

        // TODO: Buat UI untuk dokter (hampir sama seperti UI tim mikrobiologi)
    }
}
