using System;
using Microsoft.Data.Analysis;
using ConsoleTables;
using ConfigurationSettings;
using System.Diagnostics;

namespace CSVAnalytics
{
    public class CSVTable
    {
        private string filepath; // folder yang isinya csv
        private string csvFile; // file CSV referensi
        private ConfigurationReader conf;

        public CSVTable(string filepath, string csvFile)
        {
            this.filepath = filepath;
            this.csvFile = csvFile;
        }
        
        public CSVTable(string csvFile)
        {
            this.conf = new ConfigurationReader();
            this.filepath = conf.config.directory;
            this.csvFile = csvFile;
        }
        
        public string GetFilePath()
        {
            return filepath + csvFile;
        }

        public bool IsCSV(string CSVFile)
        {
            string ext = Path.GetExtension(CSVFile);
            return ext == ".csv";
        }

        public void DelData()
        {
            Console.WriteLine("Anda akan menghapus data pola kuman. Yakin (y/n)?");

            string yn = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(yn), "Pilihan tidak boleh null");

            switch (yn)
            {
                case "y":
                    Console.WriteLine("Menghapus file " + filepath + csvFile + "...");
                    File.Delete(filepath + csvFile);
                    break;
                case "n": Console.WriteLine("Data tidak dihapus.\n"); break;
                default: Console.WriteLine("Pilihan tidak valid. Kembali ke menu...\n"); break;
            }
        }


        public void ChangeRef() // ganti referensi di folder yang sama
        {
            Console.Write("Anda akan mengganti pola kuman ke file yang baru. Yakin (y/n)? ");
            string yn = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(yn), "Pilihan tidak boleh null");

            switch (yn)
            {
                case "y":
                    Console.WriteLine("Masukkan nama file baru dengan ekstensi.");
                    Console.WriteLine("Contoh: file.csv");
                    Console.Write("Tabel anda: ");
                    string csvChange = Console.ReadLine();

                    if (!File.Exists(filepath+csvChange))
                    {
                        Console.WriteLine("File tidak tersedia!");
                    }
                    else if (!IsCSV(csvChange))
                    {
                        Console.WriteLine("File bukan CSV");
                    }
                    else
                    {
                        csvFile = csvChange;
                    }
                    break;
                case "n": Console.WriteLine("Tidak ganti referensi"); break;
                default: Console.WriteLine("Pilihan tidak valid!"); break;
            }
        }

        public void CsvStats()
        {
            var df = DataFrame.LoadCsv(filepath + csvFile);
            string ignored = "Number of isolates";

            foreach (var col in df.Columns)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i] == null || col[i] == DBNull.Value)
                    {
                        col[i] = 0.0f;
                    }
                }
            }

            var accessedCol = df["Organism"]; // inisialisasi
            Console.Write("Masukkan spesies bakteri: ");

            string accessed = Console.ReadLine()?.ToLower();
            Debug.Assert(!string.IsNullOrEmpty(accessed), "Species Bakteri tidak boleh null");

            string ignoredCol = "Organism";
            List<int> kept = new List<int>();

            for (int i = 0; i < df.Rows.Count; i++)
            {
                if (!df.Rows[i][ignoredCol].ToString().Equals(ignored))
                {
                    kept.Add(i);
                }
            }

            for (int i = 0; i < df.Columns.Count; i++)
            {
                if (df.Columns[i].Name.ToLower() == accessed.ToLower())
                {
                    accessedCol = df[df.Columns[i].Name]; // supaya case insensitive
                }
            }

            df = df[kept];

            var correlatingCol = df[ignoredCol];

            var pairedvalues = new List<(object, object)>();
            for (int i = 0; i < Math.Min(accessedCol.Length, correlatingCol.Length); i++)
            {
                pairedvalues.Add((accessedCol[i], correlatingCol[i]));
            }

            var sortedval = pairedvalues.OrderByDescending(pair => pair.Item1);

            var threeLargest = sortedval.Take(3);

            foreach (var pair in threeLargest)
            {
                Console.WriteLine(pair.Item2 + " - " + pair.Item1 + "%"); // console
            }
            Console.WriteLine();
        }

        public List<(object, object)> CsvStats(string column)
        {
            var df = DataFrame.LoadCsv(filepath); // GUI ga perlu ketik file
            string ignored = "Number of isolates";

            foreach (var col in df.Columns)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i] == null || col[i] == DBNull.Value)
                    {
                        col[i] = 0.0f;
                    }
                }
            }

            var accessedCol = df["Organism"]; // Inisialisasi

            Debug.Assert(!string.IsNullOrEmpty(column), "Species Bakteri tidak boleh null");

            string ignoredCol = "Organism";
            List<int> kept = new List<int>();

            for (int i = 0; i < df.Rows.Count; i++)
            {
                if (!df.Rows[i][ignoredCol].ToString().Equals(ignored))
                {
                    kept.Add(i);
                }
            }

            for (int i = 0; i < df.Columns.Count; i++)
            {
                if (df.Columns[i].Name.ToLower() == column.ToLower())
                {
                    accessedCol = df[df.Columns[i].Name]; // supaya case insensitive
                }
            }

            df = df[kept];

            var correlatingCol = df[ignoredCol];

            var pairedvalues = new List<(object, object)>();
            for (int i = 0; i < Math.Min(accessedCol.Length, correlatingCol.Length); i++)
            {
                pairedvalues.Add((accessedCol[i], correlatingCol[i]));
            }

            var sortedval = pairedvalues.OrderByDescending(pair => pair.Item1);

            var threeLargest = sortedval.Take(3);

            return threeLargest.ToList();
        }

        public void showCSV()
        {
            var df = DataFrame.LoadCsv(filepath + csvFile);

            ConsoleTable table = new ConsoleTable(df.Columns.Select(c => c.Name).ToArray());
            foreach (var row in df.Rows)
            {
                object[] rowdata = new object[df.Columns.Count];
                for (int i = 0; i < df.Columns.Count; i++)
                {
                    rowdata[i] = row[i] ?? 0.0f;
                }

                table.AddRow(rowdata);
            }

            table.Write(Format.Alternative);
        }

        public DataFrameColumn[] ShowColumn(string columnName)
        {
            DataFrame df = DataFrame.LoadCsv(filepath + csvFile);

            for(int i = 0; i < df.Columns.Count; i++)
            {
                if (df.Columns[i].Name.Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    DataFrameColumn[] FoundColumns =
                    {
                        df.Columns[0],
                        df.Columns[i]
                    };
                    return FoundColumns;
                }
            }
            DataFrameColumn[] defaultColumns =
            {
                df.Columns[0],
                df.Columns[1]
            };
            return defaultColumns;
        }

        public DataFrame SerializeDataFrame()
        {
            DataFrame df = DataFrame.LoadCsv(filepath + csvFile);
            return df;
        }
    }
}