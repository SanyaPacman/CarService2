using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnection.Tables
{
    public class Sale: Entity
    {
        private int saleValue;
        public int SaleValue
        {
            get { return saleValue; }
            set
            {
                saleValue = value;
                OnPropertyChanged("SaleValue");
            }
        }
    }
}
