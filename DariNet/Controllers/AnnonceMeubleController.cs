using DariNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DariNet.Controllers
{
    public class AnnonceMeubleController : Controller
    {
        // GET: AnnonceMeuble
        public ActionResult Index()
        {

            IEnumerable<AnnonceMeuble> annoncesMeuble = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-all-muebleAnnounce");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AnnonceMeuble>>();
                    readTask.Wait();

                    annoncesMeuble = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    annoncesMeuble = Enumerable.Empty<AnnonceMeuble>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(annoncesMeuble);
        }

        // GET: AnnonceMeuble/Details/5
        public ActionResult Details(int id)
        {

            AnnonceMeuble ANNONCEMEUBLE = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-announceMeuble/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AnnonceMeuble>();
                    readTask.Wait();

                    ANNONCEMEUBLE = readTask.Result;
                }
            }
            return View(ANNONCEMEUBLE);

        }

        // GET: AnnonceMeuble/Create
        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(AnnonceMeuble annonceMeuble, List<HttpPostedFileBase> imageFiles)
        {
            List<String> images = new List<String>();
            foreach (HttpPostedFileBase postedFile in imageFiles)
            {
                images.Add(postedFile.FileName);
                annonceMeuble.images = images;
            }
            string path = Server.MapPath("~/UploadedFiles/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (HttpPostedFileBase postedFile in imageFiles)
            {
                if (postedFile != null)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(path + fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");

                //HTTP POST

                var postTask = client.PostAsJsonAsync<AnnonceMeuble>("add-muebleAnnounce", annonceMeuble);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    Response.Write("<script language=javascript>alert('Announce added succefuly')</script>");
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(annonceMeuble);
        }





        public ActionResult Edit(int id)
        {
            AnnonceMeuble ANNONCEMEUBLE = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-announceMeuble/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AnnonceMeuble>();
                    readTask.Wait();

                    ANNONCEMEUBLE = readTask.Result;
                }
            }
            return View(ANNONCEMEUBLE);
        }


        [HttpPost]
        public ActionResult Edit(AnnonceMeuble annonceMeuble)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<AnnonceMeuble>("modify-announceMeuble", annonceMeuble);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(annonceMeuble);
        }

        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




            HttpResponseMessage response = await client.DeleteAsync("remove-announceMeuble/" + id);

            return RedirectToAction("Index");
        }


        public ActionResult PrixAsc()
        {

            IEnumerable<AnnonceMeuble> annoncesMeuble = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-all-muebleAnnounce-price-Asc");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AnnonceMeuble>>();
                    readTask.Wait();

                    annoncesMeuble = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    annoncesMeuble = Enumerable.Empty<AnnonceMeuble>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return RedirectToAction("Index", annoncesMeuble);
        }
        public ActionResult PrixDesc()
        {

            IEnumerable<AnnonceMeuble> annoncesMeuble = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
                //HTTP GET
                var responseTask = client.GetAsync("retrieve-all-muebleAnnounce-price-Desc");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AnnonceMeuble>>();
                    readTask.Wait();

                    annoncesMeuble = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    annoncesMeuble = Enumerable.Empty<AnnonceMeuble>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View("Index", annoncesMeuble);
        }
        [HttpPost]
        public ActionResult Index(string type)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8091/Dari/All/AnnonceMeuble/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response  = new HttpResponseMessage();
            if (String.IsNullOrEmpty(type))
            {
                response = Client.GetAsync("retrieve-all-muebleAnnounce").Result;

            }
            else if (type == "V")
            {
                response = Client.GetAsync("retrieve-all-muebleAnnounce-price-Asc").Result;

            }
            else if (type == "A")
            {
                response = Client.GetAsync("retrieve-all-muebleAnnounce-price-Desc").Result;
            }
           
            IEnumerable<AnnonceMeuble> Annonces;
            if (response.IsSuccessStatusCode)
            {
                Annonces = response.Content.ReadAsAsync<IEnumerable<AnnonceMeuble>>().Result;
            }
            else
            {
                Annonces = null;
            }
            return View(Annonces);
        }
        public ActionResult Acheter(int ID)
        {
            return RedirectToAction("Create", "Livraison",ID);
        }


        }
}
