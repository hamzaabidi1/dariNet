using DariNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DariNet.Controllers
{
    public class LivraisonController : Controller
    {
        // GET: Livraison
        public ActionResult Index()
        {
            IEnumerable<Livraison> livraison = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-all-Livraison");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Livraison>>();
                    readTask.Wait();

                    livraison = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    livraison = Enumerable.Empty<Livraison>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(livraison);
        }

        // GET: Livraison/Details/5
        public ActionResult Details(int id)
        {
            Livraison livraison = null;
            livraison.livraisonStatus = "encours";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-Livraison/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Livraison>();
                    readTask.Wait();

                    livraison = readTask.Result;
                }
            }
            return View(livraison);
        }

        // GET: Livraison/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livraison/Create
        [HttpPost]
        public ActionResult Create(Livraison livraison)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Livraison>("add-Livraison", livraison);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(livraison);
        }

        // GET: Livraison/Edit/5
        public ActionResult Edit(int id)
        {
            Livraison livraison = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-Livraison/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Livraison>();
                    readTask.Wait();

                    livraison = readTask.Result;
                }
            }
            return View(livraison);
        }

        // POST: Livraison/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Livraison livraison)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Livraison>("livraison", livraison);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(livraison);
        }

     

        // POST: Livraison/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/Livraison/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("remove-Livraison?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
