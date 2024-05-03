using System;

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
    }
