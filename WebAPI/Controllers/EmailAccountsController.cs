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
    public class EmailAccountsController : ApiController
    {
        private Facade _facade = new Facade();

        // GET: api/EmailAccounts
        public IEnumerable<EmailAccount> GetEmailAccounts()
        {
            return _facade.EmailAccountRepo.GetAll(); ;
        }

        // GET: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult GetEmailAccount(int id)
        {
            EmailAccount emailAccount = _facade.EmailAccountRepo.Get(id);
            if (emailAccount == null)
            {
                return NotFound();
            }

            return Ok(emailAccount);
        }

        // PUT: api/EmailAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmailAccount(int id, EmailAccount emailAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailAccount.ID)
            {
                return BadRequest();
            }

            try
            {
                _facade.EmailAccountRepo.Edit(emailAccount);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmailAccounts
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult PostEmailAccount(EmailAccount emailAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _facade.EmailAccountRepo.Add(emailAccount);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = emailAccount.ID }, emailAccount);
        }

        // DELETE: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult DeleteEmailAccount(int id)
        {
            EmailAccount emailAccount = _facade.EmailAccountRepo.Get(id);
            if (emailAccount == null)
            {
                return NotFound();
            }

            _facade.EmailAccountRepo.Remove(id);

            return Ok(emailAccount);
        }
        
    }
}