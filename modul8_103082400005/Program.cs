using System;
using System.Collections.Generic;

namespace modul8_103082400005
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig appConfig = new BankTransferConfig();
            ConfigData config = appConfig.config;

            if (config.lang == "en")
            {
                 Console.WriteLine("Please insert the amount of money to transfer:"); 
            }
            else
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:"); 
            }

            int transferAmount;
            while (!int.TryParse(Console.ReadLine(), out transferAmount))
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                }
                else
                {
                    Console.WriteLine("Input tidak valid, masukkan angka.");
                }
            }

            int transferFee;
            if (transferAmount <= config.transfer.threshold){
                transferFee = config.transfer.low_fee;
            }
            else
            {
                transferFee = config.transfer.high_fee;
            }
            
            int totalAmount = transferAmount + transferFee;

            if (config.lang == "en")
            {
               Console.WriteLine($"Transfer fee = {transferFee}"); 
               Console.WriteLine($"Total amount = {totalAmount}"); 
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {transferFee}");
                Console.WriteLine($"Total biaya = {totalAmount}");
            }

            if (config.lang == "en")
            {
                Console.WriteLine("Select transfer method:");
            }
            else
            {
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

            Console.ReadLine();

            if (config.lang == "en")
            {
                Console.Write($"Please type \"{config.confirmation.en}\" to confirm the transaction: ");
            }
            else
            {
                Console.Write($"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi: ");
            }

            string userConfirmation = Console.ReadLine();
            string expectedConfirmation;
            if (config.lang == "en")
            {
                expectedConfirmation = config.confirmation.en;
            }
            else
            {
                expectedConfirmation = config.confirmation.id;
            }

            if (userConfirmation == expectedConfirmation)
            {
                if (config.lang == "en") Console.WriteLine("The transfer is completed");
                else Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                if (config.lang == "en") Console.WriteLine("Transfer is cancelled");
                else Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}