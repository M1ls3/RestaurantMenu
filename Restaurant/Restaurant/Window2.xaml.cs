using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            dishes = new List<Dish>();
            Loader();
        }

        List<Dish> dishes;

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int idx = listBox.SelectedIndex;
            if (idx < 0 || idx >= dishes.Count)
            {
                MessageBox.Show("Оберіть рівно одну страву");
                return;
            }
            Window1 win1 = new Window1(dishes[idx]);
            win1.ShowDialog();
            try
            {
                listBox.Items[idx] = dishes[idx].ToString();
            }
            catch
            {
                MessageBox.Show("Помилка в змінені, або збережені даних в listBox");
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            Dish newDish = new Dish();
            Window1 win1 = new Window1(newDish);
            win1.ShowDialog();
            try
            {
                listBox.Items.Add(newDish.ToString());
                dishes.Add(newDish);
            }
            catch
            {
                MessageBox.Show("Помилка в створенні нової страви");
            }
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
                dishes = JsonConvert.DeserializeObject<List<Dish>>(json);

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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText("all_dishes.json", JsonConvert.SerializeObject(dishes));
        }
    }
}
