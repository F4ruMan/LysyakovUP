using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;

namespace LysyakovUP.Classes
{
    public class Order
    {
        int id;
        string orderNumber;
        int customerID;
        DateTime orderDate;
        string payMethod;

        public Order(string orderNumber, int customerID, DateTime orderDate, string payMethod)
        {
            this.orderNumber = orderNumber;
            this.customerID = customerID;
            this.orderDate = orderDate;
            this.payMethod = payMethod;
        }

        public int Id { get => id; set => id = value; }
        public string OrderNumber { get => orderNumber; set => orderNumber = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public string PayMethod { get => payMethod; set => payMethod = value; }
        public static string GetNumber()
        {
            Random random = new Random();
            string orderNumber;
            bool isUnique;

            do
            {
                char[] letters = new char[4];
                for (int i = 0; i < 4; i++)
                {
                    letters[i] = (char)('A' + random.Next(0, 26));
                }
                int numbers = random.Next(0, 100);

                // Формируем номер заказа
                orderNumber = $"{new string(letters)}-{numbers:D2}";

                // Проверяем уникальность
                isUnique = !App.orders.Any(o => o.OrderNumber == orderNumber);

            } while (!isUnique);

            return orderNumber;
        }
        public static void Save()
        {
            string filePath = "Saves\\Order.json";
            string json = JsonSerializer.Serialize(App.orders, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public static void Load()
        {
            string filePath = "Saves\\Order.json";
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                App.orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(data);
            }
        }
    }
}
