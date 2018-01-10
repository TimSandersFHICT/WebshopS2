using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Models;

namespace S2WebshopOpdracht.Controllers
{
    public class LoginController : Controller
    {
        private AccountLogic accountlogic = new AccountLogic();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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

        //Ik maak een nieuwe methode aan voor login 
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                //Maak een account aan genaamd loggedinuser
                Account loggedInUser = accountlogic.Login(username, password);

                //Sla bepaalde gegevens van de loggedinuser op in een session 
                Session["Username"] = loggedInUser.Username;
                Session["AccountId"] = loggedInUser.Id;

                //Hier kan je variabelen aanmaken om een loggedinuser naar andere pagina's te sturen
                return RedirectToAction("Index", "Home");




            }
            catch (Exception)
            {
                return View("Index");
            }

        }
    }
}
