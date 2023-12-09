using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum Type
    {
        [Description("Холодні закуски")]
        ColdSnacks,
        [Description("Перші страви")]
        FirstCourses,
        [Description("Другі страви")]
        SecondCourses,
        [Description("Десерти")]
        Desserts,
        [Description("Напої")]
        Drinks,
        [Description("NULL")]
        NULL
    }

    [Serializable]
    public class Category
    {
        public Type category;

        public Category()
        {
            category = Type.NULL;
        }

        public Category(Type category)
        {
            this.category = category;
        }

        public static class EnumHelper
        {
            public static string GetDescription(Enum value)
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                return value.ToString();
            }

            public static Type GetTypeFromDescription(string description)
            {
                foreach (Type type in Enum.GetValues(typeof(Type)))
                {
                    string typeDescription = GetDescription(type);
                    if (typeDescription == description)
                    {
                        return type;
                    }
                }
                throw new ArgumentException("No matching enum value found for the given description.");
            }
        }

        public override string ToString()
        {
            return EnumHelper.GetDescription(category);      
        }
    }

    [Serializable]
    public class Cook
    {
        private string name;
        private string surname;

        public string Name { get { return name; } set {  name = value; } }
        public string Surname { get {  return surname; } set {  surname = value; } }

        public Cook()
        {
            this.name = string.Empty;
            this.surname = string.Empty;
        }

        public Cook(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return $"{name} {surname}";
        }
    }

    //interface Interface
    //{
    //    Category Category { get; }  // ??
    //    Cook Cook { get; }
    //}

    [Serializable]
    public class Dish
    {
        private Category category { get; set; }
        private string dishName;
        private long cost;
        private long time;
        private Cook cook { get; set; }

        public Category Category { get { return category; } set { category = value; } } // Поліморфізм
        public string DishName { get { return dishName; } set { dishName = value; } } // Поліморфізм
        public long Cost { get { return cost; } set { cost = value; } } // Поліморфізм
        public long Time { get { return time; } set { time = value; } } // Поліморфізм
        public Cook Cook { get {  return cook; } set {  cook = value; } } // Поліморфізм

        public Dish(string dishName, long cost, long time, Category category, Cook cook) // Поліморфізм
        {
            this.dishName = dishName;
            this.cost = cost;
            this.time = time;
            this.category = category;
            this.cook = cook;
        }

        public Dish() // Поліморфізм
        {
            category = new Category();
            dishName = "";
            cost = 0;
            time = 0;
            cook = new Cook();
        }

        public override string ToString()
        {
            long bills = cost / 100;
            long pennies = cost % 100;
            return $"Категорія: {category}; Назва страви: \"{dishName}\"; Вартість: ({bills} грн. {pennies} коп.); Час оцікування: {time} сек.; Кухар: {cook}";
        }
    }

    [Serializable]
    public class Order
    {
        private string cafeName = "Top Cafe";
        public Dish dish = new Dish();

        public Order(Dish dish)
        {
            this.dish = (dish);
        }

        public override string ToString()  // Поліморфізм
        {
            return $"Дата: {DateTime.Today}; Назва закладу: \"{cafeName}\"; Замовлення ({dish}) \n";
        }

        public virtual string ToShortString()  // Поліморфізм
        {
            return $"Дата: {DateTime.Today}; Назва закладу: \"{cafeName}\"; Час очікування: {dish.Time.ToString()} сек.\n";
        }
    }
}
