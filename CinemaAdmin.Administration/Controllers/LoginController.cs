using CinemaAdmin.Administration.Models;
using CinemaAdmin.Domain;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CinemaAdmin.Administration.Controllers
{
    public class LoginController : Controller
    {
        private IAccountRepository AccountRepo;

        public LoginController(IAccountRepository accountRepo)
        {
            AccountRepo = accountRepo;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginOverview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginOverview(Account account)
        {
            if (ModelState.IsValid)
            {
                //         LoginController controller = new LoginController(null);
                if (IsValid(account.Username, account.Password))
                {
                    FormsAuthentication.SetAuthCookie(account.Username, true);

                    HttpCookie loginCookie = new HttpCookie("loginCookie");
                    loginCookie.Value = account.Username;
                    loginCookie.Expires = DateTime.Now.AddDays(0.2);
                    Response.Cookies.Add(loginCookie);

                    HttpCookie workCookie = new HttpCookie("workCookie");
                    workCookie.Value = AccountRepo.Accounts.Where(a => a.Username == account.Username).Select(a => a.Type).FirstOrDefault();
                    workCookie.Expires = DateTime.Now.AddDays(0.2);
                    Response.Cookies.Add(workCookie);


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(account);
        }

        public bool IsValid(String username, String password)
        {
            bool result;
            result = false;
            // .Select(p => p.Password)
            LoginModel model = new LoginModel();
            //        model.accounts = AccountRepo.Accounts.Where(p => p.ID == 1);
            String passwordByUsername = AccountRepo.Accounts.Where(p => p.Username.Equals(username)).Select(p => p.Password).FirstOrDefault();
            result = password.Equals(passwordByUsername);

            return result;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            if (Request.Cookies["loginCookie"] != null)
            {
                Response.Cookies["loginCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["workCookie"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}