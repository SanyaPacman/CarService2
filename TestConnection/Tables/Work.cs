using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnection.Tables
{
    class Work: Entity
    {
        private string workType;
        private int specificationId;
        private int price;

        public string WorkType
        {
            get { return workType; }
            set
            {
                workType = value;
                OnPropertyChanged("WorkType");
            }
        }
        public int SpecificationId
        {
            get { return specificationId; }
            set
            {
                specificationId = value;
                OnPropertyChanged("SpecificationId");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
    }
}
