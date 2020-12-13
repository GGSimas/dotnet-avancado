namespace ProjBiblio.Domain.Entities
{
    public class CampanhaMarketingLivro
    {
        public int CampanhaId { get; set; }
        public CampanhaMarketing CampanhaMarketing { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}