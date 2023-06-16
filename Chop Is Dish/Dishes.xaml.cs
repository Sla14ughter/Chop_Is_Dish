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
using System.Data;

namespace Chop_Is_Dish
{
    /// <summary>
    /// Логика взаимодействия для Dishes.xaml
    /// </summary>
    public partial class Dishes : Page
    {
        public MySqlConnection sqlConn { get; set; }
        public Dishes()
        {
            InitializeComponent();
        }

        public Dishes(string connString)
        {
            try
            {
                InitializeComponent();
                sqlConn = new MySqlConnection(connString);
                sqlConn.Open();
                DataTable dt = new DataTable();
                new MySqlDataAdapter("select * from Category", sqlConn).Fill(dt);
                CmbCategory.ItemsSource = dt.DefaultView;
                CmbCategory.SelectedItem = CmbCategory.Items[0];
                CmbCategory_SelectionChanged(CmbCategory, null);
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}"); }
            finally { sqlConn.Close(); }
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                DataTable dt = new DataTable();
                new MySqlDataAdapter($"select Name, Photo from Dish where CategoryId = '{CmbCategory.SelectedValue}' and Name like ('%{TxtSearch.Text}%')", sqlConn).Fill(dt);
                LViewDishes.ItemsSource = dt.DefaultView;
                TxtSearch.Text = "";
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}"); }
            finally { sqlConn.Close(); }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                DataTable dt = new DataTable();
                new MySqlDataAdapter($"select Name, Photo from Dish where CategoryId = '{CmbCategory.SelectedValue}' and Name like ('%{TxtSearch.Text}%')", sqlConn).Fill(dt);
                LViewDishes.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}"); }
            finally { sqlConn.Close(); }
        }

        private void NavigateToSelectedDish(object sender, MouseButtonEventArgs e)
        {
            //todo: Обработать нажатие на блюдо
        }
    }
}
