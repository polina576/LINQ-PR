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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQ_пример
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> person=new List<Person>();
        public MainWindow()
        {
            InitializeComponent();

            person.Add(new Person("Tom ", 18));
            person.Add(new Person("Bob ", 38));
            person.Add(new Person("Sam ", 29));
            person.Add(new Person("Bill ", 19));
            person.Add(new Person("Tim ", 20));
            person.Add(new Person("Tomas ", 14));
        }

      
        //загрузить
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            foreach (Person person in person)
            {
                lbPerson.Items.Add(person.Name+ "" + person.Age.ToString());
            }
        }
        //получить год рождения
        private void birthdayBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var persone = from p in person
                          select new
                          {
                              FirstName = p.Name,
                              Year = DateTime.Now.Year - p.Age
                          };
            foreach (var p in persone)
                resultList.Items.Add($"{p.FirstName} - {p.Year}");

        }
        //Получить имя
        private void nameBtn_Click_1(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            foreach (Person person in person)
            {
                resultList.Items.Add(person.Name);
            }
        }
        //возраст менее 20 лет
        private void agethreeBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            resultList.Items.Clear();
            var selectedPerson = from p in person
                                 where p.Age < 20
                                 select p;
            foreach (Person person in selectedPerson)
                resultList.Items.Add(person.Age);
        }

        //сортировка возрастов по убыванию
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var orderNumbers = from p in person
                               orderby p.Age descending
                               select p;
            foreach (var p in orderNumbers)
                resultList.Items.Add($"{p.Name} - {p.Age}");
        }
        //сортировка имен по алфавиту
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var orderNumbers = from p in person
                               orderby p.Name
                               select p;
            foreach (var p in orderNumbers)
                resultList.Items.Add(p.Name);
        }
        //количество записей
        private void KolBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            int kol = person.Count();
                resultList.Items.Add(kol);
        }
        //имя и возраст самого младшего
        private void yuongBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
           var minAge = person.OrderBy(p => p.Age).First();

            resultList.Items.Add($"{minAge.Name} - {minAge.Age}");
        }
        //имя начинается на Т и возраст больше 18
        private void nametBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var persone = from p in person
                          where p.Age > 18
                          where p.Name.ToUpper().StartsWith("T")
                          select p;
            foreach (Person p in persone)
                resultList.Items.Add($"{p.Name} - {p.Age}");

        }

        private void srdBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var avaregeAge = person.Average(p => p.Age);
            resultList.Items.Add(avaregeAge);
        }
        //сумма всех возрастов
        private void sumBtn_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            var sumAge = person.Sum(p => p.Age);
            resultList.Items.Add(sumAge);
        }
        //последние две записи
        private void poslBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = person.Skip(4);
            foreach (var p in result)
                resultList.Items.Add($"{ p.Name} {p.Age}");
        }
        //Имя больше 3 симоволов
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();   
            var selectedPerson = person.Where(p => p.Name.Length >4);

            foreach (var person in selectedPerson)
                resultList.Items.Add(person.Name);
        }
    }
}
