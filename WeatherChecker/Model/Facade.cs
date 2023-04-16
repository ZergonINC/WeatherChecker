using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.Model
{
    internal class Facade
    {
        //https://api.openweathermap.org/data/2.5/weather?id={city id}&appid=91fa0d8a621a9d3464505cb62a21a29a&units=metric&lang=ru
        //Если потребуется можно добавить метод с поиском по кординатам или любой другой, просто создав еще один класс
        //https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=91fa0d8a621a9d3464505cb62a21a29a&units=metric&lang=ru
        DataWeather DataByWeather { get; set; }

        WeatherRequest weatherRequest;

        internal Facade(DataWeather dataByIP)
        {
            this.DataByWeather = dataByIP;

            weatherRequest = new();
        }

        internal async Task<DataWeather> Operation(string city)
        {
            string weatherApi = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=91fa0d8a621a9d3464505cb62a21a29a&units=metric&lang=ru";

            DataByWeather = await weatherRequest.SendRequest(weatherApi);

            return DataByWeather;
        }
    }
}
