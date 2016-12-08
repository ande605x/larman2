﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    public class Dag : INotifyPropertyChanged
    {


        public ItemsChangeObservableCollection<TilmeldteHuse> Alletilmeldtehuse { get; set;  }

        public Dag(ItemsChangeObservableCollection<TilmeldteHuse> huse )
        {
            Alletilmeldtehuse = huse;
        }




        /// <summary>
        /// Lægger alle husenes antal kuverter sammen og returner dem.
        /// </summary>
        /// <returns></returns>
        public double SumKuvertDag()
        {
            double sum = 0;

            foreach (var h in Alletilmeldtehuse)
            {
                sum += h.GetAntalKuverter();
            }
            return sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
