using DAL;
using Model.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class SearchCriteriasController : ApiController
    {
        private Facade _facade = new Facade();

        // GET: api/SearchCriterias
        public IEnumerable<SearchCriteria> GetSearchCriterias()
        {
            return _facade.SearchCriteriaRepo.GetAll();
        }

        // GET: api/SearchCriterias/5
        [ResponseType(typeof(SearchCriteria))]
        public IHttpActionResult GetSearchCriteria(int id)
        {
            SearchCriteria searchCriteria = _facade.SearchCriteriaRepo.Get(id);

            if (searchCriteria == null)
            {
                return NotFound();
            }

            return Ok(searchCriteria);
        }

        // PUT: api/SearchCriterias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSearchCriteria(int id, SearchCriteria searchCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != searchCriteria.ID)
            {
                return BadRequest();
            }
            try
            {
                _facade.SearchCriteriaRepo.Edit(searchCriteria);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SearchCriterias
        [ResponseType(typeof(SearchCriteria))]
        public IHttpActionResult PostSearchCriteria(SearchCriteria searchCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _facade.SearchCriteriaRepo.Add(searchCriteria);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = searchCriteria.ID }, searchCriteria);
        }

        // DELETE: api/SearchCriterias/5
        [ResponseType(typeof(SearchCriteria))]
        public IHttpActionResult DeleteSearchCriteria(int id)
        {
            SearchCriteria searchCriteria = _facade.SearchCriteriaRepo.Get(id);
            if (searchCriteria == null)
            {
                return NotFound();
            }

            _facade.SearchCriteriaRepo.Remove(id);

            return Ok(searchCriteria);
        }

    }
}