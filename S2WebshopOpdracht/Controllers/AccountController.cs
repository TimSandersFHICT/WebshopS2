using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Models;


namespace S2WebshopOpdracht.Controllers
{
    public class AccountController : Controller
    {
        private AccountLogic accountlogic = new AccountLogic();

        // GET: Account
        public ActionResult Index()
        {
            List<Account> accounts = accountlogic.GetAllAccounts();
            return View(accounts);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            Account account = accountlogic.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Customer customer = new Customer(collection["CreditCardInfo"], collection["PhoneNumber"], collection["FirstName"], collection["LastName"], collection["ShippingInfo"], Convert.ToInt32(collection["AccountID"]), Convert.ToInt32(collection["AddressID"]), collection["Username"], collection["Password"], collection["Email"]);
                accountlogic.InsertCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            Account account = accountlogic.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer = new Customer(id, Convert.ToInt32(collection["AddressID"]), collection["Username"], collection["Password"], collection["Email"]);
                accountlogic.UpdateAccount(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            Account account = accountlogic.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                accountlogic.DeleteCustomer(id);
                accountlogic.DeleteAddress(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
