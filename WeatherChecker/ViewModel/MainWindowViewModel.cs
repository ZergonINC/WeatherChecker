using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherChecker.Model;

namespace WeatherChecker.ViewModel
{
    //Простенькая viewmodel, просто объявляем свойства и присваиваем и значения.

    public class MainWindowViewModel : BaseViewModel
    {
        private string _cityField = "";
        public string CityField
        {
            get { return _cityField; }

            set
            {
                _cityField = value;
                RaisePropertyChanged(nameof(CityField));
            }
        }

        private DataWeather _weather;
        public DataWeather Weather
        {
            get { return _weather; }

            set
            {
                _weather = value;
                RaisePropertyChanged(nameof(Weather));
            }
        }

        private string _cityNameField;
        public string CityNameField
        {
            get { return _cityNameField; }

            set
            {
                _cityNameField = value;
                RaisePropertyChanged(nameof(CityNameField));
            }
        }

        private string _weatherMainField;
        public string WeatherMainField
        {
            get { return _weatherMainField; }

            set
            {
                _weatherMainField = value;
                RaisePropertyChanged(nameof(WeatherMainField));
            }
        }

        private string _weatherDescripField;
        public string WeatherDescripField
        {
            get { return _weatherDescripField; }

            set
            {
                _weatherDescripField = value;
                RaisePropertyChanged(nameof(WeatherDescripField));
            }
        }

        private double _tempMainField;
        public double TempMainField
        {
            get { return _tempMainField; }

            set
            {
                _tempMainField = value;
                RaisePropertyChanged(nameof(TempMainField));
            }
        }

        private double _tempFeelsField;
        public double TempFeelsField
        {
            get { return _tempFeelsField; }

            set
            {
                _tempFeelsField = value;
                RaisePropertyChanged(nameof(TempFeelsField));
            }
        }

        private int _pressureField;
        public int PressureField
        {
            get { return _pressureField; }

            set
            {
                _pressureField = value;
                RaisePropertyChanged(nameof(PressureField));
            }
        }
 
        private int _humidityField;
        public int HumidityField
        {
            get { return _humidityField; }

            set
            {
                _humidityField = value;
                RaisePropertyChanged(nameof(HumidityField));
            }
        }

        private int _visibilityField;
        public int VisibilityField
        {
            get { return _visibilityField; }

            set
            {
                _visibilityField = value;
                RaisePropertyChanged(nameof(VisibilityField));
            }
        }

        private double _windSpeedField;
        public double WindSpeedField
        {
            get { return _windSpeedField; }

            set
            {
                _windSpeedField = value;
                RaisePropertyChanged(nameof(WindSpeedField));
            }
        }

        private double _windGustField;
        public double WindGustField
        {
            get { return _windGustField; }

            set
            {
                _windGustField = value;
                RaisePropertyChanged(nameof(WindGustField));
            }
        }

        private int _windDegField;
        public int WindDegField
        {
            get { return _windDegField; }

            set
            {
                _windDegField = value;
                RaisePropertyChanged(nameof(WindDegField));
            }
        }

        private int _cloudsField;
        public int CloudsField
        {
            get { return _cloudsField; }

            set
            {
                _cloudsField = value;
                RaisePropertyChanged(nameof(CloudsField));
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

                    CityNameField = Weather.name;
                    WeatherMainField = Weather.weather.First().main;
                    WeatherDescripField = Weather.weather.First().description;
                    TempMainField = Weather.main.temp;
                    TempFeelsField = Weather.main.feels_like;
                    PressureField = Weather.main.pressure;
                    HumidityField = Weather.main.humidity;
                    VisibilityField = Weather.visibility;
                    WindSpeedField = Weather.wind.speed;
                    WindDegField = Weather.wind.deg;
                    WindGustField = Weather.wind.gust;
                    CloudsField = Weather.clouds.all;
                });
            }
        }
    }

}
