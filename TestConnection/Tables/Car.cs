using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnection.Tables
{
    class Car : Entity
    {
        private string carNumber;
        private string mark;
        private string model;
        private int clientId;
        private int masterId;
        private int workId;
        public string CarNumber
        {
            get { return carNumber; }
            set
            {
                carNumber = value;
                OnPropertyChanged("CarNumber");
            }
        }
        public string Mark
        {
            get { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged("Mark");
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        public int ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
        public int MasterId
        {
            get { return masterId; }
            set
            {
                masterId = value;
                OnPropertyChanged("MasterId");
            }
        }
        public int WorkId
        {
            get { return workId; }
            set
            {
                workId = value;
                OnPropertyChanged("WorkId");
            }
        }
    }
}
