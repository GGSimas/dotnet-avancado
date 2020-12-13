using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/Genero")]
    public class GeneroController: ControllerBase
    {
        private IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            this._generoService = generoService;   
        }

        [HttpGet]
        public GeneroListViewModel Get() {
            var generos = _generoService.Get();

            return generos;
        }

        [HttpGet("{id}", Name="GetGeneroDetails")]
        public ActionResult<GeneroViewModel> GetById(int id) {
            var genero = _generoService.Get(id);

            if (genero == null) {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody]GeneroInputModel genero) {
            var generoAdd = _generoService.Post(genero);

            return new CreatedAtRouteResult("GetGeneroDetails", new { Id = generoAdd.Id }, generoAdd);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]GeneroInputModel genero) {
            if (id != genero.Id) {
                return BadRequest();
            }

            var generoUpd = _generoService.Put(id, genero);
            return new CreatedAtRouteResult("GetGeneroDetails", new { Id = generoUpd.Id}, generoUpd);
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneroViewModel> Delete(int id) {
            var generoDelete = _generoService.Delete(id);

            if (generoDelete == null) {
                return NotFound();
            }

            return generoDelete;
        }
    }
}