using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DariNet.Controllers
{
    public class LivraisonController : Controller
    {
        // GET: Livraison
        public ActionResult Index()
        {
            return View();
        }

        // GET: Livraison/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livraison/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livraison/Create
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

        // GET: Livraison/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Livraison/Edit/5
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

        // GET: Livraison/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livraison/Delete/5
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
