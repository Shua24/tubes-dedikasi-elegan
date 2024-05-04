using CSVAnalytics;
using ConfigurationSettings;


internal class Program
{
    private static void Main(string[] args)
    {
        string fp = @"D:/Codes/"; // TODO: Jangan pakai default ini (Shua)
                                  // TODO: Ganti intro ke setup direktori default (Tunggu Zawin dan Aufa)

        Console.WriteLine("Anda perlu memberikan referensi pertama. Masukkan nama file dengan ekstensi.");
        Console.WriteLine("Contoh: file.csv");
        Console.Write("File anda: ");
        string def = fp + Console.ReadLine();

        CSVTable tab = new CSVTable(fp);

        if (!File.Exists(def))
        {
            Console.WriteLine("File tidak ditemukan!");
            return;
        }


        if (!CSVTable.ExtCheck(def))
        {
            Console.WriteLine("File bukan CSV!");
            return;
        }


        while (true)
        {
            menu();
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: tab.showCSV(def); break;
                case 2: tab.CsvStats(def); break;
                case 3: Console.WriteLine(def + "\n"); break;
                case 4: tab.DelData(fp); break;
                case 5: def = tab.ChangeRef(fp); break;
                case 6:

                    Console.WriteLine("Terima kasih sudah memilih aplikasi ini!\n");
                    Environment.Exit(0);
                    break;

                default: Console.WriteLine("Pilihan tidak valid!\n"); break;
            }
        }
    }

    private static void menu()
    {
        Console.WriteLine("Menu penghitungan tabel data responsivitas kuman terhadap antibiotik.");
        Console.WriteLine("Responsivitas dihitung dalam persentase, dimana 0% berarti bakteri kebal terhadap antibiotik. Pilih opsi:");
        Console.WriteLine("1. Tampilkan tabel");
        Console.WriteLine("2. Masukkan bakteri");
        Console.WriteLine("3. Tampilkan sumber tabel (direktori)");
        Console.WriteLine("4. Hapus pola kuman");
        Console.WriteLine("5. Update pola kuman ke file yang baru");
        Console.WriteLine("6. Keluar");
        Console.Write("Pilihan anda: ");
    }
}