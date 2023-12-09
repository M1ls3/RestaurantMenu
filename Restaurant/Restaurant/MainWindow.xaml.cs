using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dishes = new List<Dish>();
            orders = new List<Order>();
            Loader();
        }

        List<Dish> dishes;
        List<Order> orders;

        private void button_Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string output = null;
                long counter = 1;
                foreach (Order ord in orders)
                {
                    output += $"[{counter}] {ord.ToShortString()} \n";
                    counter++;
                }
                if (!string.IsNullOrEmpty(output))
                    MessageBox.Show($"Ти замовив {orders.Count} страв. \n{output}");
                else throw new Exception("Замовлення пусте. \nОбери страву!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void button_OrderList_Click(object sender, RoutedEventArgs e)
        {
            int idx = listBox.SelectedIndex;
            if (idx < 0 || idx >= dishes.Count)
            {
                MessageBox.Show("Виберіть рівно одну страву");
                return;
            }
            orders.Add(new Order(dishes[idx]));
        }

        private void CreateJson(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, new List<Dish>());
                }
            }
        }

        public List<Dish> JsonDeserialize(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                dishes = JsonConvert.DeserializeObject<List<Dish>>(json); // Використання поліморфізму через параметр типу:
                                                                          // У методі JsonDeserialize використовується параметр типу List<Dish>,
                                                                          // що дозволяє методу працювати з об'єктами типу List<Dish>
                                                                          // незалежно від конкретної реалізації.

                foreach (Dish dish in dishes)
                {
                    listBox.Items.Add(dish.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не вдалося здійснити десеріалізацію JSON файлу. Деталі: {e}");
                CreateJson(path);
                dishes = new List<Dish>();
            }
            return dishes;
        }

        private void Loader()
        {
            try
            {
                dishes = JsonDeserialize("all_dishes.json");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Помилка в десерелізації json файлу. Деталі: {e}");
            }
        }

        private void button_Admin_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.ShowDialog();
            win2.Activate();
        }
    }
}