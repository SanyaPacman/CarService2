using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestConnection.Tables
{
    class Master:Entity
    {
        private string name;
        private int specificationId;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
    }    
}
