using Microsoft.Web.Http;
using MyPhoneBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPhoneBookApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/phonebook")]
    public class PhoneBookController : ApiController
    {
        [Route("contacts")]
        public List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact
                {
                    FirstName = "Robin",
                    LastName = "Hood"
                }
            };
        }
    }
}
