using DAL.Context;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace DAL.Repository
{
    public class EmailAccountRepository : IRepository<EmailAccount>
    {
        CollaboratorContext db = new CollaboratorContext();


        public EmailAccount Add(EmailAccount entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Email");
                }
                var accountAdded = db.EmailAccounts.Add(entity);
                db.SaveChanges();
                return accountAdded;
            }

        }

        public void Edit(EmailAccount entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public EmailAccount Get(int id)
        {
            return db.EmailAccounts.Find(id);

        }

        public IEnumerable<EmailAccount> GetAll()
        {
            return db.EmailAccounts;

        }

        public void Remove(int id)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                var account = db.EmailAccounts.Find(id);
                db.EmailAccounts.Remove(account);
                db.SaveChanges();
            }
        }
    }
}