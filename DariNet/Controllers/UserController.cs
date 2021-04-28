using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DariNet.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Security;


namespace DariNet.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Users()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:8091/Dari/All/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("getAllUsers").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }
        // GET: User
        public ActionResult ConnctedUsers()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:8091/Dari/All/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("getConnctedUsers").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Signup()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Signup( SignUpRequest signUp)

        {
           // SignUpRequest user;
           // if (ModelState.IsValid)
           // {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
                string json = JsonConvert.SerializeObject(signUp);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/auth/signup", httpContent);
                Console.WriteLine("/***************************");
               // user = response.Content.ReadAsAsync<SignUpRequest>().Result;
                //Session["name"] = user.name;

                //return View("Welcome");
           // }
            return View("Login");
        }
        public ActionResult logout()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> logout(User user)

        {
            // SignUpRequest user;
            // if (ModelState.IsValid)
            // {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
            string json = JsonConvert.SerializeObject(user);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/logout", httpContent);
            Console.WriteLine("/***************************");
           
            return RedirectToAction("Login");
        }

        // GET: User/Edit/5-
        public ActionResult ResetPassword()
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> ResetPassword([Bind(Include = "token,password")] LoginRequest sign)
        {
            LoginRequest user1;
            if (ModelState.IsValid)
            { 

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
                string json = JsonConvert.SerializeObject(sign);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/reset", httpContent);
               
            }

            return RedirectToAction("Welcome");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> ForgetPassword( LoginRequest sign)
        {
           // LoginRequest user1;
            if (ModelState.IsValid)
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
                string json = JsonConvert.SerializeObject(sign);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/forget", httpContent);


                return RedirectToAction("ResetPassword");
            }
            return View("ResetPassword");
        }
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Login([Bind(Include = "username,password")] LoginRequest sign)
        {
            LoginRequest user1;
            if (ModelState.IsValid)
            {


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
                string json = JsonConvert.SerializeObject(sign);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/auth/signin", httpContent);
                Console.WriteLine("/***************************");
                user1 = response.Content.ReadAsAsync<LoginRequest>().Result;
                Session["name"] = user1.username;
         

                if (String.IsNullOrEmpty(user1.username) )
                {
                    ViewBag.erreur = user1.message;
                }else
                {
                    return RedirectToAction("welcome");
                }



            }
            return View();


        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            ViewBag.name = Session["name"];
            return View();
        }

        
        public ActionResult GetMyInfo()
        {
            
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:8091/Dari/All/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("getMyInfo").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }
     
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> UpdateUser(User user )
        {
            // app.UseAuthentication();
            //  httpClient.DefaultRequestHeaders.Authorization =
            // new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            
            

            if (ModelState.IsValid)
            {
                
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8091/Dari/All/");
                string json = JsonConvert.SerializeObject(user);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/updateUser", httpContent);

            }

            return RedirectToAction("Welcome");
        }
        public ActionResult UpdateUser()
        {
            return View();
        }

    }

}
