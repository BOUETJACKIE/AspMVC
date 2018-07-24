using Roomy.Areas.BackOffice.Models;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;
using Roomy.Filters;

namespace Roomy.Areas.BackOffice.Controllers
{
    
    public class AuthenticationController : Controller

    {
        private RoomyDbContext db = new RoomyDbContext();


        // GET: BackOffice/Authentication
        public ActionResult Login()
        {
            return View();
        }

        //POST: BackOffice/Authentication/Login  
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthentictionLoginViewModels model)
        {
            if (ModelState.IsValid)

            {
                var passwordHash = model.Password.HashMD5();
                var user = db.Users.SingleOrDefault(x => x.Email == model.Login && x.Password == passwordHash);
                if (user == null)
                {
                    ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");
                    return View(model);
                }
                else
                {
                    Session.Add("USER_BO", user);
                    TempData["Message"] = $"Utilisateur {user.Firstname} connecté.";

                    return RedirectToAction("index", "Dashboard", new { area = "BackOffice" });
                }
            }

return View(model);


        }
        //Get:BackOffice/Authentification/Logout
        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Home", new { area = "" });


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}