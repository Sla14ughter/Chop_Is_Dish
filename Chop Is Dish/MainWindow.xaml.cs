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
using MySqlConnector;

namespace Chop_Is_Dish
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDishes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Dishes("server=openserver;database=MyRecipes;uid=root;pwd=''"));
        }

        private void BtnIngredients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Ingredients());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
