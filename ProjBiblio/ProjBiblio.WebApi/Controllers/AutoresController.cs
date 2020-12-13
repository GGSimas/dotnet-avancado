using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/Autores")]

    public class AutoresController  : ControllerBase
    {
        private IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            this._autorService = autorService;
        }

        [HttpGet]
        public AutorListViewModel Get()
        {
            return _autorService.Get();
        }

        [HttpGet("{id}", Name="GetDetails")]
        public ActionResult<AutorViewModel> Get(int id) 
        { 
            var result = _autorService.Get(id);

            if (result == null)
                return NotFound();

            return result;
        }

        /// <summary> Incluir um novo autor </summary>
        /// <remarks>
        /// Exemplo de Requisição:
        /// Post/Autor {
            /// id: int,
            /// nome: string
            /// }
        /// </remarks>
        /// <param item="autor" />
        /// <returns> 200</returns> 
        [HttpPost]
        public ActionResult Post([FromBody] AutorInputModel autor)
        {
            var result = _autorService.Post(autor);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AutorInputModel autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            var result = _autorService.Put(id, autor);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<AutorViewModel> Delete(int id)
        {
            var result = _autorService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("listautoreslivro/{id}")]
        public IList<AutorSelectListDto> ListagemAutoresPorLivro(int id)
        {
            var result = _autorService.ListagemAutoresPorLivro(id);

            return result;
        }
    }
}