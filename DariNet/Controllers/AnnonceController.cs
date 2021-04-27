using DariNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace DariNet.Controllers
{
    public class AnnonceController : Controller
    {
        // GET: Annonce
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Dari/All/Annonce/retrieve-all-announces").Result;
            IEnumerable<Annonce> Annonces;
            if (response.IsSuccessStatusCode)
            {
                Annonces = response.Content.ReadAsAsync<IEnumerable<Annonce>>().Result;
            }
            else
            {
                Annonces = null;
            }

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var item in Annonces)
            {
                if (item.numberOfVisits > 0)
                    dataPoints.Add(new DataPoint(item.region, item.numberOfVisits));
            }
            //dataPoints.Add(new DataPoint("Fruit", 26));


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);



            return View(Annonces);
        }
        [HttpPost]
        public ActionResult Index(string filtre, string type)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            if (String.IsNullOrEmpty(filtre))
            {
                response = Client.GetAsync("Dari/All/Annonce/retrieve-all-announces").Result;
            }
            else if (type == "V")
            {
                response = Client.GetAsync("Dari/All/Annonce/retrieve-Announces-ville/" + filtre).Result;

            }
            else if (type == "R")
            {
                response = Client.GetAsync("Dari/All/Annonce/retrieve-all-Announces-region/" + filtre).Result;
            }
            else
            {
                response = Client.GetAsync("Dari/All/Annonce/retrieve-Announces-adresse/" + filtre).Result;
            }
            IEnumerable<Annonce> Annonces;
            if (response.IsSuccessStatusCode)
            {
                Annonces = response.Content.ReadAsAsync<IEnumerable<Annonce>>().Result;
            }
            else
            {
                Annonces = null;
            }
            return View(Annonces);

        }


        // GET: Annonce/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Annonce/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "title,description,categorie,prix,adresse,type,surface,status,date,nbreChambre,region,ville,numberOfVisits,photo")] Annonce annonce, HttpPostedFileBase imageFile)
        {


            annonce.photo = imageFile.FileName;

            if (imageFile.ContentLength > 0)
            {
                imageFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Upload"), imageFile.FileName));
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string json = JsonConvert.SerializeObject(annonce);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Dari/All/Annonce/add-Announce", httpContent);

            return RedirectToAction("Index");
        }

        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




            HttpResponseMessage response = await client.DeleteAsync("Dari/All/Annonce/remove-announce/" + id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit([Bind(Include = "title, description, categorie, prix, adresse, type, surface, status, date, nbreChambre, region, ville, numberOfVisits")] Annonce annonce)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string json = JsonConvert.SerializeObject(annonce);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Dari/All/Annonce/add-Announce", httpContent);

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
            HttpResponseMessage response = Client.GetAsync("Dari/All/Annonce/retrieve-announcee/" + id).Result;
            Annonce annonce;
            if (response.IsSuccessStatusCode)
            {
                annonce = response.Content.ReadAsAsync<Annonce>().Result;
            }
            else
            {
                annonce = null;
            }

            return View(annonce);
        }
    }
}










