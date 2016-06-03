using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandoraWeb.Models.Common;

namespace PandoraWeb.Controllers.Common
{
    public class DocumentGridViewController : Controller
    {
        // GET: DocumentGridView
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DocumentGridViewPartial()
        {
            var model = new List<DocumentGridViewModel> { new DocumentGridViewModel { Code = string.Empty, Quantity = 1, UnitPrice = 0m } };
            return PartialView("~/Views/DocumentGridView/_DocumentGridViewPartial.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] PandoraWeb.Models.Common.DocumentGridViewModel item)
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
            return PartialView("~/Views/DocumentGridView/_DocumentGridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] PandoraWeb.Models.Common.DocumentGridViewModel item)
        {
            var model = new object[0];
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
            return PartialView("~/Views/DocumentGridView/_DocumentGridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentGridViewPartialDelete(System.String Code)
        {
            var model = new object[0];
            if (Code != null)
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
            return PartialView("~/Views/DocumentGridView/_DocumentGridViewPartial.cshtml", model);
        }
    }
}