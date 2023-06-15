using MySqlConnector;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chop_Is_Dish
{
    /// <summary>
    /// Логика взаимодействия для Ingredients.xaml
    /// </summary>
    public partial class Ingredients : Page
    {
        public Ingredients()
        {
            InitializeComponent();
        }

        private void DGridIngredients_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select i.Name, i.Cost, i.CostForCount, i.AvailableCount, u.Name as Unit from Ingredient i join Unit u on i.UnitId = u.Id", "server=openserver;database=MyRecipes;uid=root;pwd=''");
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            DGridIngredients.DataContext = dt;
        }

        private void LinkEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LinkDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BorderPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
