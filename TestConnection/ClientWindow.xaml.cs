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
using System.Data.Entity;
using TestConnection.Tables;

namespace TestConnection
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
       // ApplicationContex db;
        public ClientWindow(ApplicationContex DB)
        {
            InitializeComponent();
            this.DataContext = DB.Clients.Local.ToBindingList();
        }


        public void Button_MainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {

        }
          
        public void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
