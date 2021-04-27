using DariNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;



namespace DariNet.Controllers
{
    public class AbonnementController : Controller
    {
        public static int ida;
        // GET: Abonnement
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Dari/All/Abonnement/retrieve-all-Abonnement").Result;
            IEnumerable<Abonnement> Abonnements;
            if (response.IsSuccessStatusCode)
            {
                Abonnements = response.Content.ReadAsAsync<IEnumerable<Abonnement>>().Result;
            }
            else
            {
                Abonnements = null;
            }

            return View(Abonnements);
        }



        // GET: Abonnement/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        // POST: Abonnement/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "id,nom,delais,type,contrat,user")] Abonnement Abonnement)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string json = JsonConvert.SerializeObject(Abonnement);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Dari/All/Abonnement/add-Abonnement", httpContent);

            return RedirectToAction("Index");


        }
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




            HttpResponseMessage response = await client.DeleteAsync("Dari/All/Abonnement/remove-Abonnement/" + id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit([Bind(Include = "id,nom,delais,type,contrat,user")] Abonnement Abonnement)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string json = JsonConvert.SerializeObject(Abonnement);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Dari/All/Abonnement/add-Abonnement", httpContent);

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Dari/All/Abonnement/retrieve-Abonnement/" + id).Result;
            HttpResponseMessage response1 = Client.GetAsync("Dari/All/Abonnement/verifyAssurance/" + id).Result;
            bool ok = response1.Content.ReadAsAsync<Boolean>().Result;
            ViewBag.ok = ok;
            Abonnement Abonnement;
            if (response.IsSuccessStatusCode)
            {
                Abonnement = response.Content.ReadAsAsync<Abonnement>().Result;
            }
            else
            {
                Abonnement = null;
            }

            return View(Abonnement);
        }
        public ActionResult Subscribe(int id)
        {
            ida = id;
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Subscribe(FormCollection formCollection)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Dari/All/Abonnement/retrieve-Abonnement/" + ida).Result;
            Abonnement ab = response.Content.ReadAsAsync<Abonnement>().Result;
            ab.type = "assurance";
            string json = JsonConvert.SerializeObject(ab);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response1 = await Client.PutAsync("Dari/All/Abonnement/modify-Abonnement/", httpContent);
            return RedirectToAction("Index");
        }
    }
}





