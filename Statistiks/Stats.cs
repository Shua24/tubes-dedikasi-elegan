using System;
using Microsoft.Data.Analysis;
using ConsoleTables;
using ConfigurationSettings;
using System.Diagnostics;

namespace CSVAnalytics
{
    public class CSVTable
    {
        private string _filePath; // folder yang isinya csv
        private string _csvFile; // file CSV referensi
        private ConfigurationReader _conf;
        private const string ColError = "Error: Bakteri tidak ditemukan";

        public CSVTable(string filePath, string csvFile)
        {
            _filePath = filePath;
            _csvFile = csvFile;

        }

        public static string GetColumnError()
        {
            return ColError;
        }
        
        public CSVTable(string csvFile)
        {
            _conf = new ConfigurationReader();
            _filePath = _conf.config.Directory;
            _csvFile = csvFile;
        }
        
        public string GetFilePath()
        {
            return _filePath + _csvFile;
        }

        public bool IsCSV(string csvFile)
        {
            string ext = Path.GetExtension(csvFile);
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
                    Console.WriteLine("Menghapus file " + _filePath + _csvFile + "...");
                    File.Delete(_filePath + _csvFile);
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
                    if (!File.Exists(_filePath + csvChange))
                    {
                        Console.WriteLine("File tidak tersedia!");
                    }
                    else if (!IsCSV(csvChange))
                    {
                        Console.WriteLine("File bukan CSV");
                    }
                    else
                    {
                        _csvFile = csvChange;
                    }
                    break;
                case "n": Console.WriteLine("Tidak ganti referensi"); break;
                default: Console.WriteLine("Pilihan tidak valid!"); break;
            }
        }

        public void CsvStats()
        {
            var df = DataFrame.LoadCsv(_filePath + _csvFile);
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
            var pairedValues = new List<(object, object)>();
            for (int i = 0; i < Math.Min(accessedCol.Length, correlatingCol.Length); i++)
            {
                pairedValues.Add((accessedCol[i], correlatingCol[i]));
            }

            var sortedVal = pairedValues.OrderByDescending(pair => pair.Item1);
            var threeLargest = sortedVal.Take(3);
            foreach (var pair in threeLargest)
            {
                Console.WriteLine(pair.Item2 + " - " + pair.Item1 + "%"); // console
            }
            Console.WriteLine();
        }

        public List<(object, object)> CsvStats(string column)
        {
            var df = DataFrame.LoadCsv(_filePath); // GUI ga perlu ketik file
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
                else
                {
                    GetColumnError();
                }
            }

            df = df[kept];
            var correlatingCol = df[ignoredCol];
            var pairedvalues = new List<(object, object)>();
            for (int i = 0; i < Math.Min(accessedCol.Length, correlatingCol.Length); i++)
            {
                pairedvalues.Add((accessedCol[i], correlatingCol[i]));
            }

            var sortedVal = pairedvalues.OrderByDescending(pair => pair.Item1);
            var threeLargest = sortedVal.Take(3);
            return threeLargest.ToList();
        }

        public void ShowCSV()
        {
            var df = DataFrame.LoadCsv(_filePath + _csvFile);
            ConsoleTable table = new ConsoleTable(df.Columns.Select(c => c.Name).ToArray());
            foreach (var row in df.Rows)
            {
                object[] rowData = new object[df.Columns.Count];
                for (int i = 0; i < df.Columns.Count; i++)
                {
                    rowData[i] = row[i] ?? 0.0f;
                }
                table.AddRow(rowData);
            }
            table.Write(Format.Alternative);
        }

        public DataFrameColumn[] ShowColumn(string columnName)
        {
            DataFrame df = DataFrame.LoadCsv(_filePath + _csvFile);
            for(int i = 0; i < df.Columns.Count; i++)
            {
                if (df.Columns[i].Name.Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    DataFrameColumn[] foundColumns =
                    {
                        df.Columns[0],
                        df.Columns[i]
                    };
                    return foundColumns;
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
            DataFrame df = DataFrame.LoadCsv(_filePath + _csvFile);
            return df;
        }
    }
}