using DariNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DariNet.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AskBot()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}