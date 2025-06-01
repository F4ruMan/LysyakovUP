using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace LysyakovUP.Classes
{
    public class Customer
    {
        int id;
        string firstName;
        string lastName;

        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public static void Save()
        {
            string filePath = "Saves\\Customer.json";
            string json = JsonSerializer.Serialize(App.customers, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static void Load()
        {
            string filePath = "Saves\\Customer.json";
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                App.customers = JsonSerializer.Deserialize<ObservableCollection<Customer>>(data);
            }
        }
    }
}
