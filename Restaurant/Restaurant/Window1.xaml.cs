using System;
using System.Collections.Generic;
using System.Data;
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

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Dish dish;
        bool sucsess = false;

        public Window1(Dish dish)
        {
            InitializeComponent();
            this.dish = dish;
            if (this.dish != null && this.dish.Category != null)
            {
                comboBox.Text = Category.EnumHelper.GetDescription(this.dish.Category.category);
                textBox.Text = this.dish.Cook.Name.ToString();
                textBox_Copy.Text = this.dish.Cook.Surname.ToString();
                textBox1.Text = this.dish.DishName.ToString();
                textBox1_Copy.Text = this.dish.Cost.ToString();
                textBox1_Copy1.Text = this.dish.Time.ToString();
            }
        }

        static bool IsNumeric(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        void Save()
        {
            if (Category.EnumHelper.GetTypeFromDescription(comboBox.Text) != Type.NULL)
                this.dish.Category.category = Category.EnumHelper.GetTypeFromDescription(comboBox.Text);
            else throw new Exception("Оберіть категорію!!");

            if (!string.IsNullOrEmpty(textBox.Text))
                this.dish.Cook.Name = textBox.Text;
            else throw new Exception("Ім'я не може бути пустим!!");

            if (!string.IsNullOrEmpty(textBox_Copy.Text))
                this.dish.Cook.Surname = textBox_Copy.Text;
            else throw new Exception("Прізвище не може бути пустим!!");

            if (!string.IsNullOrEmpty(textBox1.Text))
                this.dish.DishName = textBox1.Text;
            else throw new Exception("Назва страви не може бути пустим!!");

            if (IsNumeric(textBox1_Copy.Text))
                this.dish.Cost = Convert.ToInt64(textBox1_Copy.Text);
            else throw new Exception("Ціна не може дорівнювати нулю, або словам!!");

            if (IsNumeric(textBox1_Copy1.Text))
                this.dish.Time = Convert.ToInt64(textBox1_Copy1.Text);
            else throw new Exception("Час не може дорівнювати нулю, або словам!!");
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Save();
                sucsess = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка в заповнені форми!! \n{ex.Message}");
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            sucsess = true;
            this.Close ();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!sucsess)
            {
                if (MessageBox.Show("Зберегти дані?", "ЩО, ВТЕКТИ ХОТІВ?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    Save();
            }
            
        }

    }
}
