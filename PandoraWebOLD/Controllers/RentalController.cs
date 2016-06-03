using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandoraWeb.Models;

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


        [ValidateInput(false)]
        public ActionResult DocumentGridViewPartial()
        {
            var model = new List<DocumentGridViewModel> {new DocumentGridViewModel { Code = string.Empty, Quantity = 1, UnitPrice = 0m } };
            return PartialView("~/Views/Shared/DocumentTemplate/_DocumentGridViewPartial.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialAddNew(DocumentGridViewModel item)
        {
            var model = new List<DocumentGridViewModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);

                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Shared/DocumentTemplate/_DocumentGridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialUpdate(DocumentGridViewModel item)
        {
            var model = new List<DocumentGridViewModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Shared/DocumentTemplate/_DocumentGridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialDelete(DocumentGridViewModel aaaa)
        {
            var model = new List<DocumentGridViewModel>();
            if (aaaa != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/Shared/DocumentTemplate/_DocumentGridViewPartial.cshtml", model);
        }

        public ActionResult DocumentGridViewPartialBatchUpdate(object item)
        {
            var model = new List<DocumentGridViewModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Shared/DocumentTemplate/_DocumentGridViewPartial.cshtml", model);
        }
    }
}
