using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmailAccountsController : ApiController
    {
        private CollaboratorContext db = new CollaboratorContext();

        // GET: api/EmailAccounts
        public IQueryable<EmailAccount> GetEmailAccounts()
        {
            return db.EmailAccounts;
        }

        // GET: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult GetEmailAccount(int id)
        {
            EmailAccount emailAccount = db.EmailAccounts.Find(id);
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

            db.Entry(emailAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            db.EmailAccounts.Add(emailAccount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emailAccount.ID }, emailAccount);
        }

        // DELETE: api/EmailAccounts/5
        [ResponseType(typeof(EmailAccount))]
        public IHttpActionResult DeleteEmailAccount(int id)
        {
            EmailAccount emailAccount = db.EmailAccounts.Find(id);
            if (emailAccount == null)
            {
                return NotFound();
            }

            db.EmailAccounts.Remove(emailAccount);
            db.SaveChanges();

            return Ok(emailAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailAccountExists(int id)
        {
            return db.EmailAccounts.Count(e => e.ID == id) > 0;
        }
    }
}