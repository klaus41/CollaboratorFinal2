using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace DAL.Context
{
    public class CollaboratorContext : DbContext
    {
        public CollaboratorContext(): base("Collaborator")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new ContextInitializer());
        }
        public DbSet<Email> Emails { get; set; }

        public DbSet<SearchCriteria> SearchCriterias { get; set; }

        public DbSet<Theme> Themes { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
    }
}