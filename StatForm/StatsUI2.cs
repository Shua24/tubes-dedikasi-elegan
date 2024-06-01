using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Microsoft.Data.Analysis;

namespace StatForm
{
    public partial class StatsUI2 : Form
    {
        public string dirReference;

        public StatsUI2(string dirReference)
        {
            InitializeComponent();
            this.dirReference = dirReference;
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

        private DataFrame DataFrameNA()
        {
            DataFrame df = DataFrame.LoadCsv(dirReference);
            FillNA(df);
            return df;
        }

        private void DataGridReference()
        {
            DataFrame df = DataFrameNA();
            DataTable dt = ToDataTable(df);
            Table.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv) | *.csv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dirReference = ofd.FileName;

                    DataFrame df = DataFrame.LoadCsv(dirReference);
                    FillNA(df);

                    DataTable dt = ToDataTable(df);
                    Table.DataSource = dt;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login(dirReference);
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(dirReference);
            Table.DataSource = null;
        }

        private void StatsUI2_Load(object sender, EventArgs e)
        {
            DataGridReference();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DokterUI2 next = new DokterUI2(dirReference);
            next.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
