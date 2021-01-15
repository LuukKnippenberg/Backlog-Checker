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
        private readonly GamesManager gamesManager = new GamesManager();

        [HttpGet]
        public IActionResult Index( string sort, string filter )
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            
            if(userId != null)
            {
                List<Game> gamesList;
                if (sort != null || filter != null)
                {
                    gamesList = gamesManager.GetGamesFiltered(filter, Convert.ToInt32(userId));
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

        [HttpGet]
        public IActionResult Game(int? gameId)
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId != null) 
            {
                if (gameId != null)
                {
                    if (gamesManager.IfGameExists((int)gameId))
                    {
                        Game game = gamesManager.GetSingleGame((int)gameId);
                        return View(game);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }                
        }

        public void DeleteGame(int gameId)
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId != null)
            {
                string rights = HttpContext.Session.GetString("rights");

                gamesManager.DeleteGame(rights, Convert.ToInt32(userId), gameId);
            }
               
        }

        [HttpGet]
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
        public IActionResult AddGame(MyGamesViewModel model)
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId != null)
            {
                GamesModelDTO DTO = new GamesModelDTO()
                {
                    Title = model.title,
                    Description = model.Description,
                    HeaderUrl = model.HeaderUrl,
                };
                try
                {
                    gamesManager.AddGame(DTO);
                    return RedirectToAction("Index", "Games");
                }
                catch
                {
                    throw new Exception("Failed to add game");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpGet]
        public IActionResult Edit(int? gameId)
        {
            Game game;
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId != null)
            {
                if (gameId != null)
                {
                    string rights = HttpContext.Session.GetString("rights");


                    if (rights != "admin")
                    {

                        return RedirectToAction("Game", new { gameId = gameId });
                    }

                    game = gamesManager.GetSingleGame((int)gameId);

                    return View(game);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }           
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId != null)
            {
                game.UpdateGame();

                return RedirectToAction("Game", new { gameId = game.Id });
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public void ToggleOwned(int gameId, string subject)
        {

            int? userId = HttpContext.Session.GetInt32("userId");

            gamesManager.ToggleUserGameRelation(gameId, subject, Convert.ToInt32(userId));
        }


    }
}
