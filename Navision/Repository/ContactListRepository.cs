﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Configuration;
using System.Web.Configuration;
using Navision.navData;

namespace Navision.Repository
{
    public class ContactListRepository : Client
    {

        public IEnumerable<ContactList> GetContacts()
        {
            NAV nav = NavOData();
            return nav.ContactList;
        }

        public ContactList GetContact(string username, string password)
        {
            NAV nav = NavOData();

            var query = nav.ContactList.Where(x => x.No == username).Where(x => x.Password == password).FirstOrDefault();

            return query;
        }


        public ContactList GetContact(string key)
        {
            NAV nav = NavOData();

            return nav.ContactList.Where(c => c.No == key).FirstOrDefault();
        }

        public IEnumerable<Portal_Company> GetCompany()
        {
            NAV nav = NavOData();

            return nav.Portal_Company;
        }
    }
}