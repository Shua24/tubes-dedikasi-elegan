using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.Arrow;
using Microsoft.Data.Analysis;

namespace StatForm
{
    public partial class StatsUI2 : Form
    {
        public StatsUI2()
        {
            InitializeComponent();
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
                    Apache.Arrow.Table.DataSource = dt;

                    string filepath = ofd.FileName;
                    directory = filepath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
