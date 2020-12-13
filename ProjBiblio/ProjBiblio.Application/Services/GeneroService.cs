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
  public class GeneroService : IGeneroService
  {
    private IUnitOfWork _uow;
    private IMapper _mapper;

    public GeneroService(IUnitOfWork uow, IMapper mapper)
    {
      this._uow = uow;
      this._mapper = mapper;
    }

    public GeneroViewModel Delete(int id)
    {
      var genero = this._uow.GeneroRepository.GetById(gen => gen.GeneroId == id);

      if (genero != null)
      {
        return null;
      }

      _uow.GeneroRepository.Delete(genero);
      _uow.Commit();
      return _mapper.Map<GeneroViewModel>(genero);
    }

    public GeneroListViewModel Get()
    {
      var generos = this._uow.GeneroRepository.Get();

      return new GeneroListViewModel()
      {
        Generos = _mapper.Map<IEnumerable<GeneroViewModel>>(generos)
      };

    }

    public GeneroViewModel Get(int id)
    {
      var genero = this._uow.GeneroRepository.GetById(gen => gen.GeneroId == id);

      return _mapper.Map<GeneroViewModel>(genero);
    }

    public GeneroViewModel Post(GeneroInputModel genero)
    {
      var generoAdd = _mapper.Map<Genero>(genero);
      _uow.GeneroRepository.Add(generoAdd);
      _uow.Commit();
      return _mapper.Map<GeneroViewModel>(generoAdd);
    }

    public GeneroViewModel Put(int id, GeneroInputModel genero)
    {
      var generoUpd = _mapper.Map<Genero>(genero);

      _uow.GeneroRepository.Update(generoUpd);
      _uow.Commit();

      return _mapper.Map<GeneroViewModel>(generoUpd);
    }
  }
}