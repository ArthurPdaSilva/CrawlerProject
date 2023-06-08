using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CrawlerProject.Entities.DTO;

namespace CrawlerProject.Entities
{
    internal class EuroExchange
    {
        public double BidPrice { get; set; }
        public double AskingPrice { get; set; }
        public DateTime Date { get; set; }
        
        public EuroExchange(EuroExchangeDTO euroExchangeDTO) {
            BidPrice = double.Parse(euroExchangeDTO.CotacaoCompra, CultureInfo.InvariantCulture);
            AskingPrice = double.Parse(euroExchangeDTO.CotacaoVenda, CultureInfo.InvariantCulture);
            Date = DateTime.Parse(euroExchangeDTO.DataHoraCotacao);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data dessa Cotação: " + Date);
            sb.AppendLine("Cotação de compra: R$ " + BidPrice);
            sb.AppendLine("Cotação de venda: R$ " + AskingPrice);

            return sb.ToString();
        }
    }
}
