using System;
using Microsoft.Data.Analysis;
using ConsoleTables;

namespace CSVAnalytics
{
    public class Stats
    {
        private string filepath; // folder yang isinya csv
        public Stats(string filepath)
        {
            this.filepath = filepath;
        }
        public string GetFilePath()
        {
            return filepath;
        }

        public static bool ExtCheck(string filepath)
        {
            string ext = Path.GetExtension(filepath);
            return ext == ".csv";
        }

        public void DelData(string filepath)
        {
            Console.WriteLine("Anda akan menghapus data pola kuman. Silakan pilih file yang dihapus (dengan extension)");
            Console.WriteLine("Contoh: file.csv");

            string csvFile = Console.ReadLine();

            Console.WriteLine("Anda yakin ingin menghapus data (y/n)?");
            string yn = Console.ReadLine();

            switch (yn)
            {
                case "y":
                    if (!File.Exists(filepath + csvFile)) Console.WriteLine("File tidak ditemukan!");
                    if (!ExtCheck(filepath + csvFile)) Console.WriteLine("File bukan CSV!");
                    Console.WriteLine("Menghapus file " + filepath + csvFile + "...");
                    File.Delete(filepath + csvFile);
                    break;
                case "n": Console.WriteLine("Data tidak dihapus.\n"); break;
                default: Console.WriteLine("Pilihan tidak valid. Kembali ke menu...\n"); break;
            }
        }

        public string ChangeRef(string filepath)
        {
            Console.Write("Anda akan mengganti pola kuman ke file yang baru. Yakin (y/n)? ");
            string yn = Console.ReadLine();
            string csvChange = string.Empty;

            switch (yn)
            {
                case "y":
                    Console.WriteLine("Masukkan nama file baru dengan ekstensi.");
                    Console.WriteLine("Contoh: file.csv");
                    csvChange = Console.ReadLine();
                    break;
                case "n": Console.WriteLine("Tidak ganti referensi"); break;
                default: Console.WriteLine("File tidak ditemukan!"); break;
            }

            return filepath + csvChange;
        }

        public void CsvStats(string filepath)
        {
            var df = DataFrame.LoadCsv(filepath);
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
                Console.WriteLine(pair.Item2 + " - " + pair.Item1 + "%");
            }
            Console.WriteLine();
        }

        public void showCSV(string filepath)
        {
            var df = DataFrame.LoadCsv(filepath);

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
    }

}