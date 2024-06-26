﻿using Microsoft.Data.Analysis;
using System.Data;
using ConfigurationSettings;

namespace StatForm
{
    public partial class StatsUI : Form
    {
        public string? newReference;

        public StatsUI(string? newReference)
        {
            InitializeComponent();
            this.newReference = newReference;
        }

        public void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private DataTable ToDataTable(DataFrame dataFrame)
        {
            DataTable dt = new();
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
            ConfigurationReader reader = new();

            using OpenFileDialog ofd = new();
            ofd.Filter = "CSV files (*.csv) | *.csv";
            ofd.InitialDirectory = reader.config.Directory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataFrame df = DataFrame.LoadCsv(ofd.FileName);
                FillNA(df);
                DataTable dt = ToDataTable(df);
                Table.DataSource = dt;
                string reference = ofd.FileName;

                Close();
                StatsUI2 statsUI = new(reference);
                statsUI.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new("");
            login.Show();
            Close();
        }
    }
}
