using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backlog_Checker.Models.Games;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Backlog_Checker.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public IActionResult Index( string sort, string filter )
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            
            if(userId != null)
            {
                List<Game> gamesList;
                GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));
                if (sort != null || filter != null)
                {
                    gamesList = gamesManager.GetGamesSortedAndOrFiltered(sort, filter, Convert.ToInt32(userId));
                }
                else
                {
                    gamesList = gamesManager.GetGamesForUserById((int)userId);
                }
                IndexViewModel model = new IndexViewModel()
                {
                    Games = gamesList
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }            
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Game(int gameId)
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            GamesModelDTO gamesModel = gamesManager.GetSingleGame(gameId);

            return View(gamesModel);
        }

        public void DeleteGame(int gameId)
        {
            string rights = HttpContext.Session.GetString("rights");
            int? userId = HttpContext.Session.GetInt32("userId");

            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            gamesManager.DeleteGame(gameId, rights, Convert.ToInt32(userId));
        }

        public IActionResult Compare()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(string title, string description, string headerUrl)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            try
            {
                gamesManager.AddGame(title, description, headerUrl);
                return RedirectToAction("Index", "Games");
            }
            catch
            {
                throw new Exception("Failed to add game");
            }
        }

        [HttpGet]
        public IActionResult Edit(int gameId)
        {
            Console.WriteLine($"gameId: {gameId}");
            int? userId = HttpContext.Session.GetInt32("userId");

            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            GamesModelDTO gamesModel = gamesManager.GetSingleGame(gameId);

            return View(gamesModel);
        }

        [HttpPost]
        public IActionResult Edit(GamesModelDTO model)
        {
            int gameId = 30; 

            Console.WriteLine($"gameId: {model.Id}");

            int? userId = HttpContext.Session.GetInt32("userId");
            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            gamesManager.EditGame(model.Id, model.Title, model.Description, model.HeaderUrl);

            return RedirectToAction("Game", new { gameId = gameId });
        }

        public void ToggleOwned(int gameId, string subject)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            GamesManager gamesManager = new GamesManager(Convert.ToInt32(userId));

            gamesManager.ToggleUserGameRelation(gameId, subject, Convert.ToInt32(userId));
        }


    }
}
