using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using TestConnection.Tables;

namespace TestConnection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        ApplicationContex db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContex();
            db.Clients.Load();
            db.Sales.Load();
            db.Masters.Load();
            db.Works.Load();
            db.Cars.Load();
            this.DataContext = db.Cars.Local.ToBindingList();

            //this.DataContext = db.Masters.Local.ToBindingList();
            //this.DataContext = db.Sales.Local.ToBindingList();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PhoneWindow phoneWindow = new PhoneWindow(new Client());
            if (phoneWindow.ShowDialog() == true)
            {
                Client phone = phoneWindow.Client;
                db.Clients.Add(phone);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (phonesList.SelectedItem == null) return;
            // получаем выделенный объект
            Client Client = phonesList.SelectedItem as Client;

            PhoneWindow phoneWindow = new PhoneWindow(new Client
            {
                Id = Client.Id,
                SaleId = Client.SaleId,
                AllSumm = Client.AllSumm,
                Name = Client.Name
            });

            if (phoneWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                Client = db.Clients.Find(phoneWindow.Client.Id);
                if (Client != null)
                {
                    Client.SaleId = phoneWindow.Client.SaleId;
                    Client.Name = phoneWindow.Client.Name;
                    Client.AllSumm = phoneWindow.Client.AllSumm;
                    db.Entry(Client).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (phonesList.SelectedItem == null) return;
            // получаем выделенный объект
            Client phone = phonesList.SelectedItem as Client;
            db.Clients.Remove(phone);
            db.SaveChanges();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
