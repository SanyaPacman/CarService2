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
        ApplicationContex db;
        // ApplicationContex db;
        public ClientWindow(ApplicationContex DB)
        {
            InitializeComponent();
            db = DB;
            this.DataContext = db.Clients.Local.ToBindingList();
        }


        public void Button_MainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            EditingClient EditWindow = new EditingClient(new Client());
            if (EditWindow.ShowDialog() == true)
            {
                Client Client = EditWindow.Client;
                db.Clients.Add(Client);
            }
        }
          
        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (clientList.SelectedItem == null) return;
            // получаем выделенный объект
            Client Client = clientList.SelectedItem as Client;

            EditingClient EditWindow = new EditingClient(new Client
            {
                Id = Client.Id,
                Name = Client.Name,
                SaleId = Client.SaleId,
                AllSumm = Client.AllSumm
            });

            if (EditWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                Client = db.Clients.Find(EditWindow.Client.Id);
                if (Client != null)
                {
                    Client.Name = EditWindow.Client.Name;
                    Client.AllSumm = EditWindow.Client.AllSumm;
                    Client.SaleId = EditWindow.Client.SaleId;
                    db.Entry(Client).State = EntityState.Modified;
                }
                clientList.Items.Refresh();
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (clientList.SelectedItem == null) return;
            // получаем выделенный объект
            Client Client = clientList.SelectedItem as Client;
            db.Clients.Remove(Client);
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
