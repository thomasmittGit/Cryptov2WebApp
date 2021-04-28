using Cryptov2WebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptov2WebApp.DataBaseExtract;
using Cryptov2WebApp.Filters;

namespace Cryptov2WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login");
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (UsersDB.ValidateLogin(vm.username, vm.senha) != null)
                    {
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não cadastrado");
                        return View(vm);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
            }
            else
            {
                return View(vm);
            }
        }

        [UserAuth]
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        } 
    }
}