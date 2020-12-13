using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class GeneroRepository: Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(BibliotecaDbContext context): base(context)
        {
            
        }
    }
}