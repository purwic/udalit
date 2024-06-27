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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Book> Books = new List<Book>();


        private void Update()
        {
            DG.ItemsSource = Books;
        }

        public MainWindow()
        {
            InitializeComponent();

            Update();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Books.RemoveAll(it => true);

            string path = @"C:\Users\rodio\OneDrive\Documents\Books.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ';' });
                    Books.Add(new Book()
                    {
                        FullName = words[0],
                        Title = words[1],
                        Year = words[2]
                    });
                }
            }

            DG.Items.Refresh();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var Filtered = Books.Where(book => int.Parse(book.Year) < 1950);
            DG.ItemsSource = Filtered;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Books.RemoveAll(book => (1000 <= int.Parse(book.Year) && 200000 >= int.Parse(book.Year)));

            Update();
            DG.Items.Refresh();
        }
    }
}
