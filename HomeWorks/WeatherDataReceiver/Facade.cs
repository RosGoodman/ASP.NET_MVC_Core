

using System.Collections.ObjectModel;

namespace WeatherDataReceiver
{
    /// <summary> Фасад. Класс, закрывающий все лишнее от пользователя. </summary>
    public class Facade
    {
        private string _YandexAddress = "https://yandex.ru/pogoda/month?lat=59.938951&lon=30.315635&via=hnav";

        public Facade() { }

        /// <summary> Получить данные о погоде с сайта Yandex. </summary>
        /// <returns> Коллекция дней с данными о погоде. </returns>
        public async Task<ObservableCollection<DayWeather>> GetWeatherFromYandexAsync()
        {
            ParserYandexWeather receiver = new ParserYandexWeather();
            return await receiver.GetMonthWeather(_YandexAddress);
        }

        /// <summary> Получить данные о погоде с сайта Google. </summary>
        /// <returns> Коллекция дней с данными о погоде. </returns>
        public async Task<List<DayWeather>> GetWeatherFromGoogleAsync()
        {
            //метод добавлен просто для примера расширяемости
            return null;
        }
    }
}
