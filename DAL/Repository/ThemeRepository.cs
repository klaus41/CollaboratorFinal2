using DAL.Context;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public class ThemeRepository : IRepository<Theme>
    {
        CollaboratorContext db = new CollaboratorContext();
        public Theme Add(Theme entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Email");
                }
                var theme = db.Themes.Add(entity);
                db.SaveChanges();
                return theme;
            }
        }

        public void Edit(Theme entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Theme Get(int id)
        {
            return db.Themes.Include(s => s.SearchCriterias)
              .Include(m => m.Emails)
              .SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<Theme> GetAll()
        {
            return db.Themes.Include(c => c.SearchCriterias);
        }

        public void Remove(int id)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                var theme = db.Emails.Find(id);
                db.Emails.Remove(theme);
                db.SaveChanges();
            }
        }
    }
}