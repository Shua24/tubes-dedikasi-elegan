﻿using CSVAnalytics;
using LoginRegister;


internal class Program
{
    private static void Main(string[] args)
    {
        UserLogin user = new UserLogin();
        

        while (true) {
            bool keluar = false;
            if (keluar)
            {
                break;
            }
            user.Login();
            if (user.getLoginState() != LoginState.SUDAH_LOGIN)
            {
                Console.WriteLine("Username atau password salah");
            }
            else
            {
                Console.WriteLine("Anda memerlukan referensi CSV pertama. Masukkan file CSV dengan ekstensinya");
                Console.Write("File anda: ");
                string csv = Console.ReadLine();

                CSVTable tab = new CSVTable(csv);

                if (!File.Exists(csv) && !tab.IsCSV(csv)) Console.WriteLine("File bukan CSV atau file tidak ada di folder!");
                while (true)
                {
                    if (user.getLoginState() != LoginState.SUDAH_LOGIN)
                    {
                        break;
                    }
                    menu();
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: tab.showCSV(); break;
                        case 2: tab.CsvStats(); break;
                        case 3: Console.WriteLine(tab.GetFilePath() + "\n"); break;
                        case 4: tab.DelData(); break;
                        case 5: tab.ChangeRef(); break;
                        case 6: user.Logout(); break;
                        case 7:
                            Console.WriteLine("Terima kasih sudah memilih aplikasi ini!\n");
                            Environment.Exit(0);
                            keluar = true;
                            break;
                        default: Console.WriteLine("Pilihan tidak valid!\n"); break;
                    }
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
        Console.WriteLine("6. Logout");
        Console.WriteLine("7. Keluar");
        Console.Write("Pilihan anda: ");
    }
}