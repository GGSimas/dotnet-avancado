using System.Collections.Generic;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;


namespace ProjBiblio.Application.Interfaces
{
    public interface ICampanhaMarketingService
    {
        CampanhaMarketingListViewModel Get();

        CampanhaMarketingViewModel Get(int id);

        CampanhaMarketingViewModel Post(CampanhaMarketingInputModel campanha);

        CampanhaMarketingViewModel Put(int id, CampanhaMarketingInputModel campanha);

        CampanhaMarketingViewModel Delete(int id);
    }
}