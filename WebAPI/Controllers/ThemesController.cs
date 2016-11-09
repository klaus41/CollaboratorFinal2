﻿using System;
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
    public class ThemesController : ApiController
    {
        private CollaboratorContext db = new CollaboratorContext();

        // GET: api/Themes
        public IQueryable<Theme> GetThemes()
        {
            return db.Themes.Include(c=>c.SearchCriterias);
        }

        // GET: api/Themes/5
        [ResponseType(typeof(Theme))]
        public IHttpActionResult GetTheme(int id)
        {
           // Theme theme = db.Themes.Find(id);
            Theme theme = db.Themes.Include(s => s.SearchCriterias)
                .Include(m=>m.Emails)
                .SingleOrDefault(x => x.ID == id);

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

            db.Entry(theme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Themes
        [ResponseType(typeof(Theme))]
        public IHttpActionResult PostTheme(Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Themes.Add(theme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = theme.ID }, theme);
        }

        // DELETE: api/Themes/5
        [ResponseType(typeof(Theme))]
        public IHttpActionResult DeleteTheme(int id)
        {
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return NotFound();
            }

            db.Themes.Remove(theme);
            db.SaveChanges();

            return Ok(theme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThemeExists(int id)
        {
            return db.Themes.Count(e => e.ID == id) > 0;
        }
    }
}