using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestConnection.Tables
{
    public class Client : Entity
    {
        private string name;
        private int saleId;
        private int allSumm;
        public ICollection<Car> Cars { get; set; }
        public Sale Sale { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int SaleId
        {
            get { return saleId; }
            set
            {
                saleId = value;
                OnPropertyChanged("SaleId");
            }
        }
        public int AllSumm
        {
            get { return allSumm; }
            set
            {
                allSumm = value;
                OnPropertyChanged("AllSumm");
            }
        }


    }
}