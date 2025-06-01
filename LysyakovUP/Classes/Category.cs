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
    public class Category
    {
        int id;
        string name;

        public Category(string name)
        {
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public static void Save()
        {
            string filePath = "Saves\\Category.json";
            string json = JsonSerializer.Serialize(App.categories, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static void Load()
        {
            string filePath = "Saves\\Category.json";
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                App.categories = JsonSerializer.Deserialize<ObservableCollection<Category>>(data);
            }
        }
    }
}
