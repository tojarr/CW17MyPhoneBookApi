using Microsoft.Web.Http;
using MyPhoneBookApi.Filters;
using MyPhoneBookApi.Models;
using MyPhoneBookApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyPhoneBookApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/phonebook")]
    [ValidationFilter]
    [ApiExceptionFilter]
    [Authorize]
    public class PhoneBookController : ApiController
    {
        //Postman
        //       {
        //"Id": "a15064c4-446b-4843-99bf-88d9aafde38a",
        //"FirstName": "Donald",
        // "LastName": "Duck",
        //       "PhoneNumbers": [
        //           "55555555",
        //           "79797979"
        //       ]
        //   }
        //********************************************************************
        //private List<Contact> contacts = new List<Contact>
        //{
        //    new Contact
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Mickey",
        //        LastName = "Mouse",
        //        PhoneNumbers = new List<string>{"12345678", "12345679"}
        //    },
        //    new Contact
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Lion",
        //        LastName = "King",
        //        PhoneNumbers = new List<string>{"77887788", "77887789", "77887780" }
        //    }
        //};


        //// GET: api/PhoneBook
        //public IEnumerable<Contact> Get()
        //{
        //    return contacts;
        //}

        //// GET: api/PhoneBook/5
        //public Contact Get(Guid id)
        //{
        //    return contacts.SingleOrDefault(c => c.Id == id);
        //}

        //// POST: api/PhoneBook
        //public void Post([FromBody]Contact contact)
        //{
        //    contacts.Add(contact);
        //}
        //*********************************************************************
        private readonly ContactRepository contactRepository;

        public PhoneBookController()
        {
            contactRepository = new ContactRepository();
        }

        //// GET: api/PhoneBook
        //public IEnumerable<Contact> Get()
        //{
        //    return contactRepository.GetAll();
        //}

        //// GET: api/PhoneBook/5
        //public Contact Get(Guid id)
        //{
        //    return contactRepository.Get(id);
        //}

        //// POST: api/PhoneBook
        //public void Post([FromBody]Contact contact)
        //{
        //    contactRepository.Create(contact);
        //}
        //*******************************************************************
        [Route("contacts")]
        public IHttpActionResult GetContact()
        {
            IEnumerable<Contact> contacts = contactRepository.GetAll();
            return contacts != null && contacts.Any()
                ? CreateResponse(HttpStatusCode.OK, contacts)
                : CreateErrorResponse(HttpStatusCode.NotFound, "No contacts found");
        }

        // GET: api/PhoneBook/5
        [Route("contacts/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            Contact contact = contactRepository.Get(id);
            return contact != null
               ? CreateResponse(HttpStatusCode.OK, contact)
               : CreateErrorResponse(HttpStatusCode.NotFound, "No contacts found");
        }

        [Route("contacts/search/{name}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchContacts(string name)
        {
            IEnumerable<Contact> contacts = contactRepository.GetAll()
                ?.Where(c => c.FullName.ToLower().Contains(name.ToLower()));

            return contacts != null && contacts.Any()
               ? CreateResponse(HttpStatusCode.OK, contacts)
               : CreateErrorResponse(HttpStatusCode.NoContent, "No contacts found");
        }

        // POST: api/PhoneBook
        [Route("contacts")]
        public IHttpActionResult Post([FromBody]Contact contact)
        {
            contactRepository.Create(contact);
            return CreateResponse(HttpStatusCode.Created);
        }

        private IHttpActionResult CreateResponse(HttpStatusCode statusCode)
        {
            HttpResponseMessage responseMsg = Request.CreateResponse(statusCode);
            return ResponseMessage(responseMsg);
        }

        private IHttpActionResult CreateResponse<T>(HttpStatusCode statusCode, T value)
        {
            HttpResponseMessage responseMsg = Request.CreateResponse(statusCode, value);
            return ResponseMessage(responseMsg);
        }

        private IHttpActionResult CreateErrorResponse(HttpStatusCode statusCode, string message)
        {
            HttpResponseMessage responseMsg = Request.CreateErrorResponse(statusCode, message);
            return ResponseMessage(responseMsg);
        }
    }
}
