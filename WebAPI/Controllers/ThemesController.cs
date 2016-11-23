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
    public class ThemesController : ApiController
    {
        private Facade _facade = new Facade();

        // GET: api/Themes
        public IEnumerable<Theme> GetThemes()
        {
            return _facade.ThemeRepo.GetAll();
        }

        // GET: api/Themes/5
        [ResponseType(typeof(Theme))]
        public IHttpActionResult GetTheme(int id)
        {
            Theme theme = _facade.ThemeRepo.Get(id);

            if (theme == null)
            {
                return NotFound();
            }

            return Ok(theme);
        }

        // PUT: api/Themes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTheme(int id, Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theme.ID)
            {
                return BadRequest();
            }

            try
            {
                _facade.ThemeRepo.Edit(theme);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Themes
        [ResponseType(typeof(Theme))]
        public IHttpActionResult PostTheme(Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _facade.ThemeRepo.Add(theme);
            }
            catch (DbUpdateException)
            {
                throw;
            }


            return CreatedAtRoute("DefaultApi", new { id = theme.ID }, theme);
        }

        // DELETE: api/Themes/5
        [ResponseType(typeof(Theme))]
        public IHttpActionResult DeleteTheme(int id)
        {
            Theme theme = _facade.ThemeRepo.Get(id);
            if (theme == null)
            {
                return NotFound();
            }

            _facade.ThemeRepo.Remove(id);

            return Ok(theme);
        }
        
    }
}