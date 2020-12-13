using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class CampanhaMarketingRepository: Repository<CampanhaMarketing>, ICampanhaMarketingRepository
    {
        public CampanhaMarketingRepository(BibliotecaDbContext context): base(context)
        {
            
        }
    }
}