﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Popups;

namespace FS_06_12_2016.Model
{
    public class TilmeldteHuse : INotifyPropertyChanged
    {

        private int antalVoksen;
        public int AntalVoksen {
            get { return antalVoksen; }
            set {
                antalVoksen = value;
                OnPropertyChanged(nameof(AntalVoksen));
            }
        }

        private int antalUng;
        public int AntalUng {
            get { return antalUng; }
            set {
                antalUng = value;
                OnPropertyChanged(nameof(AntalUng));
            }
        }

        private int antalBarn;
        public int AntalBarn {
            get { return antalBarn; }
            set {
                antalBarn = value;
                OnPropertyChanged(nameof(AntalBarn));
            }
        }

        private double dagsPris;
        public double DagsPris {
            get { return dagsPris; }
            set {
                dagsPris = value;
                OnPropertyChanged(nameof(DagsPris));
            }
        }

        private string husNr;
        public string HusNr {
            get { return husNr; }
            set {
                {
                    if (value.All(char.IsNumber))
                        husNr = value;
                    else
                        MessageDialog();
                }

                OnPropertyChanged(nameof(HusNr));
            }
        }

        private string _minrolle;

        public string MinRolle {
            get { return _minrolle; }
            set {
                _minrolle = value;
                OnPropertyChanged(nameof(MinRolle));
            }
        }


        /// <summary>
        /// Denne metode aktiverer en besked til brugeren, hvis den indtastede værdi 
        /// ikke stemmer overens med hvad der er tilladt at indtaste.
        /// </summary>
        private async void MessageDialog()
        {
            var dialog = new MessageDialog("Prøv lige igen.");
            dialog.Title = "Husnumre må kun bestå af hele positive tal";
            await dialog.ShowAsync();
        }

        /// <summary>
        /// returnere huset antal kuverter
        /// </summary>
        /// <returns></returns>
        public double GetAntalKuverter()
        {
            double AntalKuverter;
            AntalKuverter = AntalVoksen + (AntalUng * 0.5) + (AntalBarn * 0.25);
            return AntalKuverter;
        }
      
        public double AntalKuverter;

        public TilmeldteHuse(string husnr, int antalvoksne, int antalung, int antalbarn,string minrolle)
        {
            this.husNr = husnr;
            this.AntalVoksen = antalvoksne;
            this.AntalUng = antalung;
            this.AntalBarn = antalbarn;
            this.AntalKuverter = GetAntalKuverter();
            this.MinRolle = minrolle;
        }

        public TilmeldteHuse()
        {
            this.MinRolle = "Ingen";
        }

        public override string ToString()
        {
            return $"Husnummer: {HusNr} \n" +
                   $"Antal Voksne: {AntalVoksen}, unge: {AntalUng} og børn: {AntalBarn}\n" +
                   $"Dagspris: {DagsPris} \n Opgave: {MinRolle}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
