using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Index(User user)
        {

            MVCTestEntities _entity = new MVCTestEntities();

           var _result =  _entity.Users.Where(x => x.Email == user.Email && x.Pws == user.Pws).ToList();

           

           if (_result.Count > 0)
           {
               Session["UserID"] = _result[0].UserID;
               if(user.Email =="admin@myshop.com")
                   return RedirectToAction("Index", "Admin");
               else
               return RedirectToAction("Index", "Shopping");


           }
           else
           {
               Session["UserID"] = null;
               return View();
           }
        }

        public ActionResult RegisterUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser( User user)
        {

            if (ModelState.IsValid)
            {
                MVCTestEntities _entity = new MVCTestEntities();
                _entity.Users.Add(user);
                _entity.SaveChanges();
                return View("Index");
            }
            else
            {
                return View();
            }
            
        }


    }
}
