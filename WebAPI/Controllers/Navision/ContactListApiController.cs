﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Navision;
using Navision.Repository;

namespace WebAPI.Controllers.Navision
{
    [Authorize]

    [RoutePrefix("api/nav")]

    public class ContactListApiController : ApiController
    {
        readonly NavFacade _nav = new NavFacade();

        [HttpGet]
        [Route("Contacts")]
        public IHttpActionResult GetContactList()
        {
            return Ok(_nav.ContactList.GetContacts());
        }

        [HttpGet]
        [Route("Contact/{key}")]
        public IHttpActionResult GetCompany(string key)
        {
            return Ok(_nav.ContactList.GetContact(key));
        }

    }
}