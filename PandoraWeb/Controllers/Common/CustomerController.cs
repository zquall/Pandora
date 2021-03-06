﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;

namespace PandoraWeb.Controllers.Common
{
    public class CustomerController : Controller
    {
        public ActionResult ComboBoxPartial()
        {
            var service = new CustomerService();
            
            return PartialView("~/Views/Document/_ComboBoxPartial.cshtml", service.GetCustomers());
        }

    }
}