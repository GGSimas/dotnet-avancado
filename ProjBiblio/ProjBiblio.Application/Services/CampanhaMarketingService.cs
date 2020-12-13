using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
  public class CampanhaMarketingService: ICampanhaMarketingService
  {
    private IUnitOfWork _uow;
    private IMapper _mapper;

    public CampanhaMarketingService(IUnitOfWork uow, IMapper mapper)
    {
      this._uow = uow;
      this._mapper = mapper;
    }

    public CampanhaMarketingViewModel Delete(int id)
    {
      var campanha = this._uow.CampanhaMarketingRepository.GetById(cam => cam.CampanhaMarketingId == id);

      if (campanha != null)
      {
        return null;
      }

      _uow.CampanhaMarketingRepository.Delete(campanha);
      _uow.Commit();
      return _mapper.Map<CampanhaMarketingViewModel>(campanha);
    }

    public CampanhaMarketingListViewModel Get()
    {
         var campanhas = this._uow.CampanhaMarketingRepository.Get();

      return new CampanhaMarketingListViewModel()
      {
        Campanhas = _mapper.Map<IEnumerable<CampanhaMarketingViewModel>>(campanhas)
      };

    }

    public CampanhaMarketingViewModel Get(int id)
    {
       var campanha = this._uow.CampanhaMarketingRepository.GetById(cam => cam.CampanhaMarketingId == id);

        return _mapper.Map<CampanhaMarketingViewModel>(campanha);
    }

    public CampanhaMarketingViewModel Post(CampanhaMarketingInputModel campanha)
    {
       var campanhaAdd = _mapper.Map<CampanhaMarketing>(campanha);
      _uow.CampanhaMarketingRepository.Add(campanhaAdd);
      _uow.Commit();
      return _mapper.Map<CampanhaMarketingViewModel>(campanhaAdd);
    }

    public CampanhaMarketingViewModel Put(int id, CampanhaMarketingInputModel campanha)
    {
       var campanhaUpd = _mapper.Map<CampanhaMarketing>(campanha);

      _uow.CampanhaMarketingRepository.Update(campanhaUpd);
      _uow.Commit();

      return _mapper.Map<CampanhaMarketingViewModel>(campanhaUpd);
    }
  }
}