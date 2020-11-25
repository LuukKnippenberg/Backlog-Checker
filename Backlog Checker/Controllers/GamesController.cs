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
        public IActionResult Index( string gameId )
        {
            Console.WriteLine(gameId);

            GamesManager gamesManager = new GamesManager();

            List<GamesModel> gamesModelsList = gamesManager.GetGames(new GamesModel());

            return View(gamesModelsList);
        }

        public IActionResult Compare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetGames(MyGamesViewModel myGameViewModel)
        {
            GamesModel gamesModel = new GamesModel();
            gamesModel.id = myGameViewModel.id;
            gamesModel.title = myGameViewModel.title;

            GamesManager gamesManager = new GamesManager();
            gamesManager.GetGames( gamesModel );

            return View();
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            GamesManager gamesManager = new GamesManager();

            List<GamesModel> gamesModelsList = gamesManager.GetGames(new GamesModel());

            return View(gamesModelsList);
        }
    }
}
