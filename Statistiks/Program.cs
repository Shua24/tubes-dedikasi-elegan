using CSVAnalytics;
using ConfigurationSettings;
using UserData;


internal class Program
{
    // TODO: Refactor sesuai login (Shua)
    // TODO: Refactor sesuai runtime config (Shua)
    private static void Main(string[] args)
    {
        LoginState err = LogInAction.login();
        if (err != LoginState.SUDAH_LOGIN)
        {
            Console.WriteLine("Username atau password salah!");
        }
        else
        {
            while (true)
            {
                menu();
                int choice = Convert.ToInt32(Console.ReadLine());

                CSVTable tab = new CSVTable();

                switch (choice)
                {
                    case 1: tab.showCSV(); break;
                    case 2: tab.CsvStats(); break;
                    case 3: Console.WriteLine(tab.GetFilePath() + "\n"); break;
                    case 4: tab.DelData(); break;
                    case 5: tab.ChangeRef(); break;
                    case 6:

                        Console.WriteLine("Terima kasih sudah memilih aplikasi ini!\n");
                        Environment.Exit(0);
                        break;

                    default: Console.WriteLine("Pilihan tidak valid!\n"); break;
                }
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