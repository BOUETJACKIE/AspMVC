using Roomy.Data;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;

namespace Roomy.Controllers
{
    public class UsersController : Controller

    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.civilities = db.Civilities.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create( User user)

        {if (ModelState.IsValid)
            {

                db.Configuration.ValidateOnSaveEnabled = false;
                user.Password = user.Password.HashMD5();
                //enregistrer en bd
                db.Users.Add(user);
                db.SaveChanges();

                //redirection 

            }
            ViewBag.civilities = db.Civilities.ToList();
            return View();
            
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}