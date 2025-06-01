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
    public class OrderDetails
    {
        int id;
        int orderID;
        int dishID;
        int quantity;
        double? unitPrice;
        double? totalAmount;

        public OrderDetails(int orderID, int dishID, int quantity, double? totalAmount)
        {
            this.orderID = orderID;
            this.dishID = dishID;
            this.quantity = quantity;
            this.totalAmount = totalAmount;
        }

        public int Id { get => id; set => id = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int DishID { get => dishID; set => dishID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double? UnitPrice { get => unitPrice; set => unitPrice = value; }
        public double? TotalAmount { get => totalAmount; set => totalAmount = value; }
        public static void Save()
        {
            string filePath = "Saves\\OrderDetails.json";
            string json = JsonSerializer.Serialize(App.orderDetails, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static void Load()
        {
            string filePath = "Saves\\OrderDetails.json";
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                App.orderDetails = JsonSerializer.Deserialize<ObservableCollection<OrderDetails>>(data);
            }
        }
    }
}
