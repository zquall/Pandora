using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using PandoraObjects.Authentication;

namespace Pithos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
        //
        // GET: /Home1/
        public ActionResult Connect()
        {
            LoginUser();
            var services = new CompanyService();
            ViewBag.Result = services.GetAdminInfo(GlobalVariables.SapSessionId);

            //var projectService = new ProjectService();
            //ViewBag.Result = projectService.Update(GlobalVariables.SapSessionId);

            //var invoiceService = new InvoiceService();
            //ViewBag.Result = invoiceService.Add(GlobalVariables.SapSessionId);


            //var creditNoteService = new CreditNoteService();
            //ViewBag.Result = creditNoteService.Add(GlobalVariables.SapSessionId, null);


            return View();
        }


        public ActionResult Logout()
        {
            if (GlobalVariables.SapSessionId != null)
            {
                var currentSessionId = GlobalVariables.SapSessionId;
                GlobalVariables.SapSessionId = null;
                var service = new AuthenticationService();
                service.Logout(currentSessionId);
            }

            return View();
        }

        public ActionResult Login()
        {
            LoginUser();


            return View();
        }

        private void LoginUser()
        {
            if (GlobalVariables.SapSessionId != null) return;
            var model = new LoginCredentials
            {
                DatabaseServer = ConfigurationManager.AppSettings["DatabaseServer"],
                DatabaseName = ConfigurationManager.AppSettings["DatabaseName"],
                DatabaseType = ConfigurationManager.AppSettings["DatabaseType"],
                DatabaseUsername = ConfigurationManager.AppSettings["DatabaseUsername"],
                DatabasePassword = ConfigurationManager.AppSettings["DatabasePassword"],
                CompanyUsername = ConfigurationManager.AppSettings["CompanyUsername"],
                CompanyPassword = ConfigurationManager.AppSettings["CompanyPassword"],
                Language = ConfigurationManager.AppSettings["Language"],
                LicenseServer = ConfigurationManager.AppSettings["LicenseServer"],
            };

            var service = new AuthenticationService();
            GlobalVariables.SapSessionId = service.Login(model);
        }

        //
        // GET: /Home1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home1/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
