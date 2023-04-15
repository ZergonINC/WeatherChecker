using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherChecker.Model;

namespace WeatherChecker.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _cityField;
        public string CityField
        {
            get { return _cityField; }

            set
            {
                _cityField = value;
                RaisePropertyChanged(nameof(_cityField));
            }
        }

        private DataWeather _weather;
        public DataWeather Weather
        {
            get { return _weather; }

            set
            {
                _weather = value;
                RaisePropertyChanged(nameof(_weather));
            }
        }

        DataWeather dataWeather;

        Facade facade;

        public MainWindowViewModel()
        {
            this.dataWeather = new();

            facade = new(dataWeather);
        }

        public ICommand CheckWeatherCommand
        {
            get
            {
                return new RelayCommand(async (parameter) =>
                {
                    Weather = await facade.Operation(CityField);

                }, (parameter) => true);
            }
        }
    }

}
