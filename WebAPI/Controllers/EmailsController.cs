<<<<<<< HEAD
﻿using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
=======
﻿using DAL;
using Model.Model;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
>>>>>>> 04eae6104b6a40a9be4195c22af14e48e731b2d3
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    [Authorize]

    [RoutePrefix("api")]

    public class EmailsController : ApiController
    {
         private Facade _facade = new Facade();

        // GET: api/Emails
        public IEnumerable<Email> GetEmails()
        {
            return _facade.EmailRepo.GetAll();
        }

        // GET: api/Emails/5
        [ResponseType(typeof(Email))]
        public IHttpActionResult GetEmail(int id)
        {
            Email email = _facade.EmailRepo.Get(id);

            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/Emails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmail(int id, Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.ID)
            {
                return BadRequest();
            }
            try
            {
                _facade.EmailRepo.Edit(email);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Emails
        [ResponseType(typeof(Email))]
        public IHttpActionResult PostEmail(Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _facade.EmailRepo.Add(email);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = email.ID }, email);
        }

        // DELETE: api/Emails/5
        [ResponseType(typeof(Email))]
        public IHttpActionResult DeleteEmail(int id)
        {
            Email email = _facade.EmailRepo.Get(id);
            if (email == null)
            {
                return NotFound();
            }
            
            _facade.EmailRepo.Remove(id);

            return Ok(email);
        }
        

    }
}