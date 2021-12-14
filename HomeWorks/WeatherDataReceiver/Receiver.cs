
using HtmlAgilityPack;
using System.Diagnostics;
using System.Net;

namespace WeatherDataReceiver;

public class Receiver
{
    public async Task<object> RequestTo(string address)
    {
        //список дней и данных по погоде
        Dictionary<int, Dictionary<PropertyNames, string>> dayValuesPairs = new Dictionary<int, Dictionary<PropertyNames, string>>();
        try
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None })
            {
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage response = await client.GetAsync(address))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var html = await response.Content.ReadAsStringAsync();
                            if (!string.IsNullOrEmpty(html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(html);

                                var cells = doc.DocumentNode.SelectNodes(".//div[@class='climate-calendar']//div[@class='climate-calendar__row']//div[@class='climate-calendar__cell']");
                                if (cells.Count > 0 && cells != null)
                                {
                                    //перебор ячеек дня
                                    foreach (var cell in cells)
                                    {
                                        var rows = cell.SelectNodes(".//div[@class='climate-calendar-day__row']");
                                        //список данных по погоде по наименованию св-ва.
                                        Dictionary<PropertyNames, string> paramNameValuesPairs = new Dictionary<PropertyNames, string>();

                                        //перебор найденных строк в ячейке дня.
                                        foreach (var row in rows)
                                        {
                                            //день месяца
                                            var nambDay = row.SelectSingleNode(".//div[@class='climate-calendar-day__day']").InnerText;
                                            if (nambDay != null)
                                                paramNameValuesPairs.Add(PropertyNames.NumbDay, nambDay);
                                            else
                                                continue;
                                            //путь к иконке
                                            var iconSrc = row.SelectSingleNode(".//img");
                                            paramNameValuesPairs.Add(PropertyNames.IconSrc, iconSrc.ToString());
                                        }
                                    }
                                }
                                else { Debug.Print("Не найден календарь погоды."); }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex) { Debug.Print(ex.Message); }

        return null;
    }
}