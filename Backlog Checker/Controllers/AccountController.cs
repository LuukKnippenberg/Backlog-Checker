using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backlog_Checker.Models.Account;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Security.Cryptography;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using ModelsDTO;

namespace Backlog_Checker.Controllers
{
    public class AccountController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            AccountsManager accountsManager = new AccountsManager();

            if(accountsManager.LoginAccount(username, password))
            {
                Account CurrentAccount = accountsManager.ReturnLoggedInUserData();
                HttpContext.Session.SetInt32("userId", CurrentAccount.Id);
                HttpContext.Session.SetString("username", CurrentAccount.Username);
                HttpContext.Session.SetString("rights", CurrentAccount.Rights);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            return View(registerViewModel);
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string passwordRepeat, string email)
        {
            AccountsManager accountsManager = new AccountsManager();

            if(password == passwordRepeat)
            {
                accountsManager.RegisterAccount(username, email, password);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            AccountsManager accountsManager = new AccountsManager();

            AccountModelDTO accountModel = accountsManager.GetAccountData(Convert.ToInt32(userId));

            return View(accountModel);
        }

        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("rights");

            return RedirectToAction("Login", "Account");
        }
    }
}
