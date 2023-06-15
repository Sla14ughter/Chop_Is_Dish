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
                MySqlDataReader reader = new MySqlCommand("select Name from Category", sqlConn).ExecuteReader();
                while (reader.Read()) CmbCategory.Items.Add(reader.GetString("Name"));
                reader.Close();
                CmbCategory.SelectedItem = CmbCategory.Items[0];
                CmbCategory_SelectionChanged(CmbCategory, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
            }
            finally 
            { 
                sqlConn.Close(); 
            }
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                MySqlDataReader reader = new MySqlCommand($"select d.Name, Photo from Dish d join Category c on d.CategoryId = c.Id where c.Name = '{CmbCategory.SelectedValue}'", sqlConn).ExecuteReader();
                object[] properties = new object[2];
                LViewDishes.Items.Clear();
                while (reader.Read())
                {
                    reader.GetValues(properties);
                    LViewDishes.Items.Add(new Dish(properties));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NavigateToSelectedDish(object sender, MouseButtonEventArgs e)
        {
            //onclick
        }
    }
}
