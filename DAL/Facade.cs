using DAL.EmailManager;
using DAL.Repository;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class Facade
    {
        private IRepository<Email> _emailRepo;
        private IRepository<Theme> _themeRepo;
        private IRepository<SearchCriteria> _scRepo;
        private IRepository<EmailAccount> _emailAccountRepo;
        private ThreadManager _threadManager;

        public IRepository<Email> EmailRepo
        {
            get
            {
                return _emailRepo == null ? _emailRepo =
                    new EmailRepository() : _emailRepo;
            }
        }

        public IRepository<Theme> ThemeRepo
        {
            get
            {
                return _themeRepo == null ? _themeRepo =
                    new ThemeRepository() : _themeRepo;
            }
        }

        public IRepository<SearchCriteria> SearchCriteriaRepo
        {
            get
            {
                return _scRepo == null ? _scRepo =
                    new SearchCriteriaRepository() : _scRepo;
            }
        }

        public IRepository<EmailAccount> EmailAccountRepo
        {
            get
            {
                return _emailAccountRepo == null ? _emailAccountRepo =
                    new EmailAccountRepository() : _emailAccountRepo;
            }
        }

        public ThreadManager ThreadManager
        {
            get
            {
                return _threadManager == null ? _threadManager =
                    new ThreadManager() : _threadManager;
            }
        }
    }
}