using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
            CarWindow carWindow = new CarWindow(new Car());
            if (carWindow.ShowDialog() == true)
            {
                Car car = carWindow.Car;
                db.Cars.Add(car);
                
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (carList.SelectedItem == null) return;
            // получаем выделенный объект
            Car Car = carList.SelectedItem as Car;

            CarWindow carWindow = new CarWindow(new Car
            {
                Id = Car.Id,
                CarNumber = Car.CarNumber,
                Mark = Car.Mark,
                Model = Car.Model,
                ClientId= Car.ClientId,
                MasterId = Car.MasterId,
                WorkId = Car.WorkId
            });

            if (carWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                Car = db.Cars.Find(carWindow.Car.Id);
                if (Car != null)
                {
                    Car.CarNumber = carWindow.Car.CarNumber;
                    Car.Mark = carWindow.Car.Mark;
                    Car.Model = carWindow.Car.Model;
                    Car.ClientId = carWindow.Car.ClientId;
                    Car.MasterId = carWindow.Car.MasterId;
                    Car.WorkId = carWindow.Car.WorkId;
                    db.Entry(Car).State = EntityState.Modified;             
                    
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (carList.SelectedItem == null) return;
            // получаем выделенный объект
            Car car = carList.SelectedItem as Car;
            db.Cars.Remove(car);
           
        }

        //кнопка для перехода к списку клиентов
        public void Button_ClientWindow(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow(db);
            clientWindow.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
