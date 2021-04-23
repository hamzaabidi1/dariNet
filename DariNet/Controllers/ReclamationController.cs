﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DariNet.Models;

namespace DariNet.Controllers
{
    public class ReclamationController : Controller
    {
        // GET: Reclamation
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8091/reclamation/retrieves-all-reclamation").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Reclamation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }


        // GET: Reclamation
        public ActionResult ReclamationNull()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:8091/reclamation/retrieves-all-reclamationNull").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Reclamation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(Reclamation rec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:8091");
            client.PostAsJsonAsync<Reclamation>("http://localhost:8091/reclamation/save-reclamation", rec).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
        }
        // GET: Reclamation/Reponse 
        [HttpGet]
        public ActionResult Repondre()
        {
            return View("Repondre");
        }

        // POST: Reclamation/Repondre
        [HttpPost]
        public ActionResult Repondre(Reclamation rec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:8091");
            client.PostAsJsonAsync<Reclamation>("http://localhost:8091/reclamation/repondre/{id}/{reponse}", rec).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index");
        }





        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reclamation/Edit/5
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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
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
