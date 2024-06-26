﻿using System.Diagnostics;
using CSVAnalytics;
using LoginRegister;

internal class Program
{
    private static void Menu()
    {
        Console.WriteLine("Menu penghitungan tabel data responsivitas kuman terhadap antibiotik.");
        Console.WriteLine("Responsivitas dihitung dalam persentase, dimana 0% berarti bakteri kebal " +
            "terhadap antibiotik. Pilih opsi:");
        Console.WriteLine("1. Tampilkan tabel");
        Console.WriteLine("2. Masukkan bakteri");
        Console.WriteLine("3. Tampilkan sumber tabel (direktori)");
        Console.WriteLine("4. Hapus pola kuman");
        Console.WriteLine("5. Update pola kuman ke file yang baru");
        Console.WriteLine("6. Logout");
        Console.WriteLine("7. Keluar");
        Console.Write("Pilihan anda: ");
    }

    private static void LoginMenu()
    {
        Console.WriteLine("1. Login sebagai tim mikrobiologi");
        Console.WriteLine("2. Login sebagai dokter");
        Console.Write("Pilihan Anda: ");
    }

    private static void MenuDoktah()
    {
        Console.WriteLine("Menu penghitungan tabel data responsivitas kuman terhadap antibiotik.");
        Console.WriteLine("Responsivitas dihitung dalam persentase, dimana 0% berarti bakteri kebal " +
            "terhadap antibiotik. Pilih opsi:");
        Console.WriteLine("1. Tampilkan tabel");
        Console.WriteLine("2. Masukkan bakteri");
        Console.WriteLine("3. Tampilkan sumber tabel (direktori)");
        Console.WriteLine("4. Logout");
        Console.WriteLine("5. Keluar");
        Console.Write("Pilihan anda: ");
    }

    private static void Main(string[] args)
    {
        UserLogin user = new();
        while (true)
        {
            bool keluar = false;
            if (keluar) break;

            Console.Clear();
            LoginMenu();

            string role = Console.ReadLine();
            Debug.Assert(!string.IsNullOrEmpty(role), "role tidak boleh kosong");
            int userRole = Convert.ToInt32(role);
            switch(userRole)
            {
                case 1: user.Login(); break;
                case 2: user.LoginDoc(); break;
            }

            Console.Clear();
            if (user.GetLoginState() != LoginState.SUDAH_LOGIN)
            {
                Console.WriteLine("Username atau password salah");
            }
            else
            {
                Console.WriteLine("Anda memerlukan referensi CSV pertama. Masukkan file CSV dengan ekstensinya");
                Console.Write("File anda: ");
                string csv = Console.ReadLine();
                Debug.Assert(!string.IsNullOrEmpty(csv), "File csv tidak boleh null");

                CSVTable tab = new CSVTable(csv);
                if (!File.Exists(csv) && !tab.IsCSV(csv))
                {
                    Console.WriteLine("File bukan CSV atau file tidak ada di folder!");
                }
                while (true)
                {
                    if (user.GetLoginState() != LoginState.SUDAH_LOGIN)
                    {
                        break;
                    }
                    else
                    {
                        if (userRole == 1)
                        {
                            Menu();
                            string pilihan = Console.ReadLine();
                            Debug.Assert(!string.IsNullOrEmpty(pilihan));
                            int choice = Convert.ToInt32(pilihan);

                            switch (choice)
                            {
                                case 1: tab.ShowCSV(); break;
                                case 2: tab.CsvStats(); break;
                                case 3: Console.WriteLine(tab.GetFilePath() + "\n"); break;
                                case 4: tab.DelData(); break;
                                case 5: tab.ChangeRef(); break;
                                case 6: user.Logout(); break;
                                case 7:
                                    Console.WriteLine("Terima kasih sudah memilih aplikasi ini!\n");
                                    Environment.Exit(0);
                                    keluar = true; break;
                                default: Console.WriteLine("Pilihan tidak valid!\n"); break;
                            }
                        }
                        else if (userRole == 2)
                        {
                            MenuDoktah();
                            string choiceStr = Console.ReadLine();
                            Debug.Assert(!string.IsNullOrEmpty(choiceStr), "Pengisian menu tidak boleh kosong");
                            int docChoice = Convert.ToInt32(choiceStr);
                            switch (docChoice)
                            {
                                case 1: tab.ShowCSV(); break;
                                case 2: tab.CsvStats(); break;
                                case 3: Console.WriteLine("\n" + tab.GetFilePath() + "\n"); break;
                                case 4: user.Logout(); break;
                                case 5:
                                    Console.WriteLine("Terima kasih sudah menggunakan aplikasi ini!");
                                    Environment.Exit(0);
                                    keluar = true; break;
                                default: Console.WriteLine("Pilihan tidak valid!"); break;
                            }
                        }
                    }
                }
            }
        }
    }
}