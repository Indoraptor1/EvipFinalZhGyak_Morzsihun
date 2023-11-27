﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvipFinalZhGyak
{
    public class DataModel : INotifyPropertyChanged
    {
        public string Brand { get; set; }
        public int MaxPrice { get; set; }
        public string SelectedType { get; set; }
        public int Days { get; set; }

        public string Summary {
            get
            {
                return $"{Brand} típusú {SelectedType} autó, összesen {Days} napra, maximum {MaxPrice} Ft";
            }
        }

        private List<Car> cars;
        public List<Car> Cars
        {
            get { return cars; }
            set
            {
                if (cars != value)
                {
                    cars = value;
                    OnPropertyChanged(nameof(Cars));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataModel()
        {
            //test car data
            Cars = new List<Car>
            {
                new Car("Toyota", "kicsi", 2449),
                new Car("BMW", "nagy", 1500)
            };
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cars)));
        }
    }
}
