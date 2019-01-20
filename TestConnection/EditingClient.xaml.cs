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
using TestConnection.Tables;
using System.Data.Entity;


namespace TestConnection
{
    /// <summary>
    /// Логика взаимодействия для EditingClient.xaml
    /// </summary>
    public partial class EditingClient : Window
    {
        ApplicationContex db;
        public Client Client { get; private set; }
        public EditingClient(Client p, ApplicationContex DB)
        {
            db = DB;
            InitializeComponent();
            Client = p;
            this.DataContext = Client;

            cbSale.ItemsSource = db.Sales.Local.ToBindingList();
            cbSale.DisplayMemberPath = "SaleValue";
            cbSale.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cbSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client.SaleId = (int)cbSale.SelectedValue;            
        }
    }

}
