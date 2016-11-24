using DAL.Context;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public class EmailRepository : IRepository<Email>
    {
        CollaboratorContext db = new CollaboratorContext();


        public Email Add(Email entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Email");
                }
                var emailAdded = db.Emails.Add(entity);
                db.SaveChanges();
                return emailAdded;
            }

        }

        public void Edit(Email entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Email Get(int id)
        {
            return db.Emails.Find(id);

        }

        public IEnumerable<Email> GetAll()
        {
            return db.Emails.Include(s => s.SearchCriteria);

        }

        public void Remove(int id)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                var email = db.Emails.Find(id);
                db.Emails.Remove(email);
                db.SaveChanges();
            }
        }
    }
}