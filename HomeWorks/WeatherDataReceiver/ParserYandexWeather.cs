
using HtmlAgilityPack;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;

namespace WeatherDataReceiver;

/// <summary> Парсер сайта Яндекс.погода. </summary>
internal class ParserYandexWeather
{
    /// <summary> Получить данные о погоде за месяц. </summary>
    /// <param name="address"> Адрес страницы. </param>
    /// <returns> Коллекция дней с данным о погоде. </returns>
    internal async Task<ObservableCollection<DayWeather>> GetMonthWeather(string address)
    {
        //список дней и данных по погоде
        ObservableCollection<DayWeather> weatherDays = new ObservableCollection<DayWeather>();

        try
        {
            using HttpClientHandler clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None };
            using HttpClient client = new HttpClient(clientHandler);
            using HttpResponseMessage response = await client.GetAsync(address);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(html))
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);

                    var rows = doc.DocumentNode.SelectNodes(".//div[@class='climate-calendar__row']");
                    //перебор найденных строк в ячейке дня.
                    foreach (var row in rows)
                    {
                        var days = row.SelectNodes(".//div[contains(@class, 'climate-calendar-day_with-history')]");

                        //перебор дней в строке
                        foreach (var day in days)
                        {
                            //список данных по погоде по наименованию св-ва.
                            DayWeather dayWeather = new DayWeather();

                            //день месяца
                            try
                            {
                                var nambDay = day.SelectSingleNode(".//div[contains(@class, 'climate-calendar-day__detailed-container-center')]//h6").InnerText;
                                dayWeather.Day = nambDay;
                            }
                            catch (Exception ex) { Debug.WriteLine(ex.Message); }

                            //путь к иконке
                            try
                            {
                                var iconSrc = day.SelectSingleNode(".//div[@class='climate-calendar-day__row']//img").Attributes["src"].Value;
                                dayWeather.IconAddress = iconSrc;
                            }
                            catch (Exception ex) { Debug.WriteLine(ex.Message); }

                            //температура днем
                            try
                            {
                                var tempDay = day.SelectSingleNode(".//div[@class='temp climate-calendar-day__temp-day']//span[@class='temp__value temp__value_with-unit']").InnerText;
                                dayWeather.TempDay = tempDay;
                            }
                            catch (Exception ex) { Debug.WriteLine(ex.Message); }

                            //температура ночью
                            try
                            {
                                var tempNight = day.SelectSingleNode(".//div[@class='temp climate-calendar-day__temp-night']//span[@class='temp__value temp__value_with-unit']").InnerText;
                                dayWeather.TempNight = tempNight;
                            }
                            catch (Exception ex) { Debug.WriteLine(ex.Message); }

                            //добавляем в список дней
                            weatherDays.Add(dayWeather);
                        }
                    }
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return weatherDays;
    }
}