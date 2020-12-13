using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Livro
    {
        public int LivroID { get; set; }

        public string Titulo { get; set; }

        public int? Quantidade { get; set; }
        public int? GeneroId { get; set; }

         public int? Ano { get; set; }

        public int? Edicao { get; set; }

        public int? Paginas { get; set; }

        public string Editora { get; set; }
        public string Foto { get; set; }

        public Genero Genero {get; set;}

        public ICollection<LivroAutor> LivAutor { get; set; }

        public ICollection<LivroEmprestimo> LivEmprestimo { get; set; }

        public ICollection<CampanhaMarketingLivro> LivCampanha { get; set; }

        public Livro()
        {
            LivAutor = new List<LivroAutor>();
            LivEmprestimo = new List<LivroEmprestimo>();
            LivCampanha = new List<CampanhaMarketingLivro>();
        }
    }
}