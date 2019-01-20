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
    /// Логика взаимодействия для CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public Car Car { get; private set; }
        ApplicationContex db;
        public CarWindow(Car p,ApplicationContex DB)
        {
            db = DB;
            InitializeComponent();
            Car = p;
            this.DataContext = Car;
            cbWork.ItemsSource = db.Works.Local.ToBindingList();
            cbWork.DisplayMemberPath = "WorkType";
            cbWork.SelectedValuePath = "Id";
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
        }
    }
}
