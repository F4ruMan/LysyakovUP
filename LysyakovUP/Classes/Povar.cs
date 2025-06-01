using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace LysyakovUP.Classes
{
    public class Povar
    {
        int id;
        string firstName;
        string lastName;
        string phoneNumber;
        string email;
        double? salary;
        string photo;

        public Povar(string firstName, string lastName, string phoneNumber, string email, double? salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.salary = salary;
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public double? Salary { get => salary; set => salary = value; }
        public string Photo { get => photo; set => photo = value; }

        public static void Save()
        {
            string filePath = "Saves\\Povar.json";
            string json = JsonSerializer.Serialize(App.povars, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }
        public static void Load()
        {
            string filePath = "Saves\\Povar.json";
            string data = File.ReadAllText(filePath);
            App.povars = JsonSerializer.Deserialize<ObservableCollection<Povar>>(data);
        }
    }
    
}
