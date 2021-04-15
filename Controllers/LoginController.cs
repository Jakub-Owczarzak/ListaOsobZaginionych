using OsobyZaginioneFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OsobyZaginioneFinal.Controllers
{
    public class LoginController : Controller
    {
        listazaginonychEntities db = new listazaginonychEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if (ModelState.IsValid)
            {
                using (listazaginonychEntities db = new listazaginonychEntities())
                {

                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Osoba");
                    }

                    else
                    {
                        ModelState.AddModelError("","Nazwa użytkownika albo hasło jest nieprawidłowe");
                    }
                    
                }
            }
       return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}