using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DariNet.Controllers
{
    public class AnnonceMeubleController : Controller
    {
        // GET: AnnonceMeuble
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnonceMeuble/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnnonceMeuble/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnonceMeuble/Create
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

        // GET: AnnonceMeuble/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnonceMeuble/Edit/5
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

        // GET: AnnonceMeuble/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnonceMeuble/Delete/5
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
