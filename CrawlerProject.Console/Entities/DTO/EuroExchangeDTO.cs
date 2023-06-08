using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CrawlerProject.Entities.DTO
{
    internal class EuroExchangeDTO
    {
        public string CotacaoCompra { get; set; }
        public string CotacaoVenda { get; set; }
        public string DataHoraCotacao { get; set; }

    }
}
