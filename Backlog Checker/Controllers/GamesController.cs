using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backlog_Checker.Models.Games;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using ModelsDTO;

namespace Backlog_Checker.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public IActionResult Index( string gameId )
        {
            GamesManager gamesManager = new GamesManager();

            List<GamesModel> gamesModelsList = gamesManager.GetGames(new GamesModel());

            return View(gamesModelsList);
        }

        [HttpPost]
        public IActionResult Index(MyGamesViewModel myGameViewModel)
        {
            GamesModel gamesModel = new GamesModel();
            gamesModel.id = myGameViewModel.id;
            gamesModel.title = myGameViewModel.title;

            GamesManager gamesManager = new GamesManager();
            gamesManager.GetGames(gamesModel);

            return View();
        }

        [HttpGet]
        public IActionResult Game(int gameId)
        {
            GamesManager gamesManager = new GamesManager();

            GamesModel gamesModel = gamesManager.GetSingleGame(gameId);

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

            GamesModel gamesModel = gamesManager.GetSingleGame(gameId);

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
