

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HomeWorks.Request;

public class HttpRequest
{
    public async Task<object> RequestTo(string address)
    {
        try
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None })
            {
                using(HttpClient client = new HttpClient(clientHandler))
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
                                if(cells.Count > 0 && cells != null)
                                {
                                    foreach (var cell in cells)
                                    {
                                        //var 
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
