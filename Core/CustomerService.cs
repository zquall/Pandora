using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataObjects.Common;

namespace Core
{
    public class CustomerService
    {
        public IEnumerable<KeyValueObject> GetCustomers ()
        {
            using (var pandoraEntities = new PandoraEntities())
            {
                return pandoraEntities.Get_Customers.Select(
                        customer => new KeyValueObject {Id = customer.CardCode, Name = customer.CardName}).ToList();
            }
        }
    }
}
