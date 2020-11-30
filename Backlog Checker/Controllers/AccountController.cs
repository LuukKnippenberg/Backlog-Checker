using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backlog_Checker.Models.Account;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using System.Security.Cryptography;

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
            return View();
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

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
