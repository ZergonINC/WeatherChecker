using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Input;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherChecker.Model
{
    public class WeatherRequest
    {
        internal async Task<DataWeather> SendRequest(string weatherApi)
        {
            // Получаем Api ответ

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(weatherApi))
            {
                // Проверяем успешность операции
                //response.EnsureSuccessStatusCode(); или так, если нужно исключение
                
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Десериализуем Api Json в специальный класс для дальнейшего взаимодействия.

                    var data = JsonConvert.DeserializeObject<DataWeather>(responseBody);

                    return data;
                }
                else
                {
                    // В случае провала проверки возвращаем пустой класс. По феншую так конечно не стоит делать, но приложение для личного использования, так что немножко можно.

                    DataWeather emptyData = new();

                    return emptyData;
                }
            }
        }
    }
}
