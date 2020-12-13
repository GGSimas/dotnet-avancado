using System;
using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class CampanhaMarketing
    {
        public int CampanhaMarketingId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double PercentualDesconto { get; set; }
        public ICollection<CampanhaMarketingLivro> LivroCampanha { get; set; }
    }
}