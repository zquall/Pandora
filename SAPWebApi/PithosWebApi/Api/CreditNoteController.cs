﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using DataObjects.Customer;
using PithosWebApi.Utils;

namespace PithosWebApi.Api
{
    public class CreditNoteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(CustomerInvoice value)
        {
            var service = new CreditNoteService();
            service.Add(GlobalVariables.SapSessionId, value);
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}