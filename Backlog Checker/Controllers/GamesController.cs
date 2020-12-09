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
                List<Game> gamesList = new List<Game>();
                GamesManager gamesManager = new GamesManager();
                if (sort != null || filter != null)
                {
                    gamesList = gamesManager.GetGamesSortedAndOrFiltered(sort, filter);
                }
                else
                {
                    gamesList = gamesManager.GetGamesForUserById((int)userId);
                }
                IndexViewModel model = new IndexViewModel()
                {
                    Games = gamesList
                };

                Console.WriteLine(sort);
                Console.WriteLine(filter);

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
            GamesManager gamesManager = new GamesManager();

            GamesModelDTO gamesModel = gamesManager.GetSingleGame(gameId);

            return View(gamesModel);
        }

        public void DeleteGame(int gameId)
        {
            GamesManager gamesManager = new GamesManager();

            gamesManager.DeleteGame(gameId);
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
            GamesManager gamesManager = new GamesManager();

            gamesManager.AddGame(title, description, headerUrl);

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int gameId)
        {
            Console.WriteLine($"gameId: {gameId}");

            GamesManager gamesManager = new GamesManager();

            GamesModelDTO gamesModel = gamesManager.GetSingleGame(gameId);

            return View(gamesModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, string title, string description, string headerUrl)
        {
            GamesManager gamesManager = new GamesManager();

            gamesManager.EditGame(id);

            return RedirectToAction("Game", new { gameId = id });
        }
    }
}
