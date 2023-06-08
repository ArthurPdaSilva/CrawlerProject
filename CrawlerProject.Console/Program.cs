using CrawlerProject.Entities;
using CrawlerProject.Entities.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrawlerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaPeriodo(moeda=@moeda,dataInicial=@dataInicial,dataFinalCotacao=@dataFinalCotacao)?@moeda=%27EUR%27&@dataInicial=%2701-01-2023%27&@dataFinalCotacao=%2707-06-2023%27&$top=100&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                JObject jsonObject = JObject.Parse(json);
                JArray arrayJson = (JArray)jsonObject["value"];
                List<EuroExchange> euroExchanges = new List<EuroExchange>();

                foreach (JToken token in arrayJson)
                {
                    EuroExchangeDTO euroExchangeDTO = token.ToObject<EuroExchangeDTO>();
                    EuroExchange euroExchange = new EuroExchange(euroExchangeDTO);
                    euroExchanges.Add(euroExchange);
                }


                foreach (var item in euroExchanges)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}