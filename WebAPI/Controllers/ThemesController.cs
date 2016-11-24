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
    [Authorize]
    public class ThemesController : ApiController
    {
<<<<<<< HEAD


        private CollaboratorContext db = new CollaboratorContext();
=======
        private Facade _facade = new Facade();
>>>>>>> 04eae6104b6a40a9be4195c22af14e48e731b2d3

        // GET: api/Themes
        public IEnumerable<Theme> GetThemes()
        {
<<<<<<< HEAD
            return db.Themes.Include(c => c.SearchCriterias);
=======
            return _facade.ThemeRepo.GetAll();
>>>>>>> 04eae6104b6a40a9be4195c22af14e48e731b2d3
        }

        // GET: api/Themes/5
        [ResponseType(typeof(Theme))]
        public IHttpActionResult GetTheme(int id)
        {
<<<<<<< HEAD
            // Theme theme = db.Themes.Find(id);
            Theme theme = db.Themes.Include(s => s.SearchCriterias)
                .Include(m => m.Emails)
                .SingleOrDefault(x => x.ID == id);
=======
            Theme theme = _facade.ThemeRepo.Get(id);
>>>>>>> 04eae6104b6a40a9be4195c22af14e48e731b2d3

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