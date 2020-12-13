using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/CampanhaMarketing")]
    public class CampanhaMarketingController: ControllerBase
    {
        private ICampanhaMarketingService _campanhaMarketing;

        public CampanhaMarketingController(ICampanhaMarketingService campanhaMarketing)
        {
            this._campanhaMarketing = campanhaMarketing;
        }

        [HttpGet]
        public CampanhaMarketingListViewModel Get() {
            var campanhas = _campanhaMarketing.Get();

            return campanhas;
        }

        [HttpGet("{id}", Name = "GetCampanhaMarketingDetails")]
        public ActionResult<CampanhaMarketingViewModel> GetById(int id) {
            var campanha = _campanhaMarketing.Get(id);

            if (campanha == null) {
                return NotFound();
            }

            return campanha;
        }

        [HttpPost]
        public ActionResult Post([FromBody]CampanhaMarketingInputModel campanha) {
            var campanhaAdd = _campanhaMarketing.Post(campanha);

            return new CreatedAtRouteResult("GetCampanhaMarketingDetails", new { Id = campanhaAdd.Id}, campanhaAdd);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]CampanhaMarketingInputModel campanha) {
            if (id != campanha.Id) {
                return BadRequest();
            }

            var campanhaUpd = _campanhaMarketing.Put(id, campanha);
            return new CreatedAtRouteResult("GetCampanhaMarketingDetails", new { Id = campanha.Id}, campanhaUpd);
        }

        [HttpDelete("{id}")]
        public ActionResult<CampanhaMarketingViewModel> Delete(int id) {
            var campanhaDelete = _campanhaMarketing.Delete(id);

            if (campanhaDelete == null) {
                return NotFound();
            }
            
            return campanhaDelete;
        }
    }
}