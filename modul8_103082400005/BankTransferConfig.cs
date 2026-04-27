using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace modul8_103082400005
{
    public class ConfigData
    {
        [JsonPropertyName("lang")]
        public string lang { get; set; }

        [JsonPropertyName("transfer")]
        public Transfer transfer { get; set; }

        [JsonPropertyName("methods")]
        public List<string> methods { get; set; }

        [JsonPropertyName("confirmation")]
        public Confirmation confirmation { get; set; }
        public class Transfer
        {
            [JsonPropertyName("threshold")]
            public int threshold { get; set; }
            [JsonPropertyName("low_fee")]
            public int low_fee { get; set; }
            [JsonPropertyName("high_fee")]
            public int high_fee { get; set; }
        }

        
        public class Confirmation
        {
            [JsonPropertyName("en")]
            public string en { get; set; }
            [JsonPropertyName("id")]
            public string id { get; set; }
        }
    }

    internal class BankTransferConfig
    {
        public ConfigData config;

        public const string filePath = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
                Console.WriteLine("Read Config file successfully.");
            }
            catch (Exception ex)
            {
                SetDefaultConfig();
                WriteNewConfig();
                Console.WriteLine($"GAGAL MEMBACA CONFIG: {ex.Message}");
            }
        }

        private void ReadConfig()
        {
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(jsonString);
        }

        private void SetDefaultConfig()
        {
            config = new ConfigData
            {
                lang = "en",
                transfer = new ConfigData.Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                confirmation = new ConfigData.Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
            Debug.WriteLine("Set default configuration.");
        }

        private void WriteNewConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
            Debug.WriteLine("New configuration written to file.");
        }

        


    }
}
