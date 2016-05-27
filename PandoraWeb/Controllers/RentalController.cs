using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandoraWeb.Controllers.Rental
{
    public class RentalController : Controller
    {
        // GET: RentalQuote
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quote()
        {
            return View();
        }

        // GET: RentalQuote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentalQuote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalQuote/Create
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

        // GET: RentalQuote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentalQuote/Edit/5
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

        // GET: RentalQuote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentalQuote/Delete/5
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
