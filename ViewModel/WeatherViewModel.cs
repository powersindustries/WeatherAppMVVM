using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;
using WeatherApp.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public WeatherViewModel()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                m_SelectedCity = new City
                {
                    LocalizedName = "Milwaukee"
                };


                m_CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature
                    {
                        Imperial = new Units
                        {
                            Value = 51
                        }
                    }
                };

            }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public async void MakeQuery()
        {
            List<City> cities = await WeatherHelper.GetCities(Query);

            Cities.Clear();

            for (int x=0; x < cities.Count; ++x)
            {
                Cities.Add(cities[x]);
            }

            MultipleCitiesAvailable = Cities.Count > 0;
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            CurrentConditions = await WeatherHelper.GetCurrentConditions(SelectedCity.Key);
            Cities.Clear();
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public SearchCommand SearchCommand { get; set; }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        private string m_Query;
        public string Query
        {
            get
            {
                return m_Query;
            }
            set
            {
                m_Query = value;
                OnPropertyChanged("Query");
            }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public ObservableCollection<City> Cities { get; set; }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        private bool m_MultipleCitiesAvailable;
        public bool MultipleCitiesAvailable
        {
            get
            {
                return m_MultipleCitiesAvailable;
            }
            set
            {
                m_MultipleCitiesAvailable = value;
                OnPropertyChanged("MultipleCitiesAvailable");
            }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        private CurrentConditions m_CurrentConditions;
        public CurrentConditions CurrentConditions
        {
            get
            {
                return m_CurrentConditions;
            }
            set
            {
                m_CurrentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        private City m_SelectedCity;
        public City SelectedCity
        {
            get
            {
                return m_SelectedCity;
            }
            set
            {
                m_SelectedCity = value;
                if (m_SelectedCity != null)
                {
                    OnPropertyChanged("SelectedCity");
                    GetCurrentConditions();
                }
            }
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
