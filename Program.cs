using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        public class UserBank
        {
            public decimal Saldo { get; set; }
            public string Key { get; set; }
            public string User { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, UserBank> bank = new Dictionary<string, UserBank>
            {
                {"Fauzan", new UserBank  {User = "Fauzan", Key = "23341", Saldo = 0}},
                { "Ucup", new UserBank  {User = "Ucup", Key = "23341", Saldo = 0}},
            };

            string currentUser = "";
            while (true)
            {
                Console.Write("Masukan User: ");
                string user = Console.ReadLine();
                Console.Write("Masukan Password: ");
                string pass = Console.ReadLine();
                if (bank.ContainsKey(user) && bank[user].Key == pass)
                {
                    Console.WriteLine("Anda Berhasil Masuk");
                    currentUser = user;
                    break;
                }
                Console.WriteLine("User/Password Salah Silakan Cobalagi!");
            }

            while (true)
            {
                Console.WriteLine("=======MENU BANK=======");
                Console.WriteLine("1.Tarik Saldo");
                Console.WriteLine("2.Cek Saldo");
                Console.WriteLine("3.Setor Tunai");
                Console.WriteLine("4.Transfer");
                Console.WriteLine("5.keluar");
                Console.Write("Pilih Menu: ");
                int menu = int.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    decimal min;
                    while (true)
                    {
                        Console.Write("Masukan Nominal: ");
                        if (decimal.TryParse(Console.ReadLine(), out min) && min > 0 && min <= bank[currentUser].Saldo)
                        {
                            bank[currentUser].Saldo -= min;
                            Console.WriteLine($"Anda Berhasil Menarik Uang Dengan Nominal: {min:F2} dan sisa saldo anda: {bank[currentUser].Saldo:F2}");
                            break;
                        }
                        Console.WriteLine("Saldo Anda kosong!");
                        break;
                    }
                }
                else if (menu == 2)
                {
                    Console.WriteLine($"Saldo Anda: {bank[currentUser].Saldo:F2}");
                }
                else if (menu == 3)
                {
                    decimal input;
                    while (true)
                    {
                        Console.Write("Masukan Nominal Yang Ingin Di Masukan: ");
                        if (decimal.TryParse(Console.ReadLine(), out input) && input > 0)
                        {
                            bank[currentUser].Saldo += input;
                            Console.WriteLine($"Saldo Anda Berhasil Di Tambahkan Sebesar: Rp.{input:F2} Saldo Anda: Rp.{bank[currentUser].Saldo:F2}");
                            break;
                        }
                        Console.WriteLine("Harap Masukan Nominal Dengan Benar!");
                    }
                }
                else if (menu == 4)
                {
                    while (true)
                    {
                        Console.Write("Masukan Username Yang Ingin Anda Trasnfer: ");
                        string userTarget = Console.ReadLine();
                        if (!bank.ContainsKey(userTarget))
                        {
                            Console.WriteLine("User Tidak Di Temukan!");
                            continue;
                        }

                        Console.Write("Masukan Nominal Transfer: Rp.");
                        if (decimal.TryParse(Console.ReadLine(), out decimal curentTransfer) && curentTransfer > 0 && curentTransfer <= bank[currentUser].Saldo)
                        {
                            bank[currentUser].Saldo -= curentTransfer;
                            bank[userTarget].Saldo += curentTransfer;
                            Console.WriteLine($"Anda Berhasil Mentransfer Kepada User-{bank[userTarget].User}, Sebesar Rp.{curentTransfer:F2}, Sisa Saldo Anda Rp.{bank[currentUser].Saldo:F2}.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Saldo Anda Kurang!");
                            break;
                        }
                    }
                }
                else if (menu == 5)
                {
                    Console.WriteLine("Anda Berhasil Keluar Dari Program: ");
                    break;
                }
                else
                {
                    Console.WriteLine("Maaf Menu Yang Anda Pilih Tidak Tersedia!");
                }
            }
        }
    }
}