using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace salcobrand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://salcobrand.cl";
            //#mCSB_110_container/li .menu-item a href (inner text)
            //var client = httpClientFactory.CreateClient();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    //
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(body);

                    HtmlNodeCollection elements = htmlDoc.DocumentNode
                        .SelectNodes("//div[contains(@class, 'inner-footer')]/div/div/div[contains(@class, 'col-sm-4 col-md-3 col-lg-3 hidden-xs')]/ul/li");
                    foreach (HtmlNode item in elements)
                    {
                        string val = item.SelectSingleNode("./a").Attributes["href"].Value;
                        Console.WriteLine($"{url}{val}");

                    }
                }
            }
        }
    }
}
