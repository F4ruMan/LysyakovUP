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
    public class Dish
    {
        int id;
        string name;
        string description;
        int categoryID;
        double price;
        string ingrediense;

        public Dish(string name, string description, int categoryID, double price, string ingrediense)
        {
            this.name = name;
            this.description = description;
            this.categoryID = categoryID;
            this.price = price;
            this.ingrediense = ingrediense;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public double Price { get => price; set => price = value; }
        public string Ingrediense { get => ingrediense; set => ingrediense = value; }
        public static void Save()
        {
            string filePath = "Saves\\Dish.json";
            string json = JsonSerializer.Serialize(App.dishes, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static void Load()
        {
            string filePath = "Saves\\Dish.json";
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                App.dishes = JsonSerializer.Deserialize<ObservableCollection<Dish>>(data);
            }
        }
    }
}
