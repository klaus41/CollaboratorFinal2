using DAL.Context;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public class SearchCriteriaRepository : IRepository<SearchCriteria>
    {
        CollaboratorContext db = new CollaboratorContext();

        public SearchCriteria Add(SearchCriteria entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("SearchCriteria");
                }
                var scAdded = db.SearchCriterias.Add(entity);
                db.SaveChanges();
                return scAdded;
            }
        }

        public void Edit(SearchCriteria entity)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public SearchCriteria Get(int id)
        {
            return db.SearchCriterias.Find(id);
        }

        public IEnumerable<SearchCriteria> GetAll()
        {
            return db.SearchCriterias.Include(s => s.Themes);
        }

        public void Remove(int id)
        {
            using (CollaboratorContext db = new CollaboratorContext())
            {
                var sc = db.SearchCriterias.Find(id);
                db.SearchCriterias.Remove(sc);
                db.SaveChanges();
            }
        }
    }
}