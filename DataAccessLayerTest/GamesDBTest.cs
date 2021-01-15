using System;
using System.Collections.Generic;
using Interfaces.Game;
using ModelsDTO;

namespace DataAccessLayerTest
{
    public class GamesDBTest : IGamesDB, IGamesManagerDB
    {

        public bool DeleteGame(int gameId)
        {
            return true;
        }

        public bool DeleteGameUserLink(int gameId, int userId)
        {
            return true;
        }

        public bool EditGame(GamesModelDTO gamesModelDTO)
        {
            return true;
        }

        public bool AddGame(GamesModelDTO gamesModelDTO)
        {
            return true;
        }

        public List<GamesModelDTO> GetAllGames(int userId)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();
            GamesModelDTO tempGamesModel = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };
            int amount = 1;

            for (int i = 0; i < amount; i++)
            {
                tempGamesModel.Id = i;
                gamesModelList.Add(tempGamesModel);     
            }

            return gamesModelList;
        }

        public List<GamesModelDTO> GetGamesForUserById(int userId)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();
            if (userId == 0)
            {
                GamesModelDTO tempGamesModel = new GamesModelDTO
                {
                    Completed = true,
                    Description = "The Description For User By Id",
                    Title = $"The Title",
                    HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png"
                };
                int amount = 10;

                for (int i = 0; i < amount; i++)
                {
                    tempGamesModel.Id = i;
                    gamesModelList.Add(tempGamesModel);
                }
            }

            return gamesModelList;
        }

        public List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>
            {
                new GamesModelDTO
                {
                    Id = 0,
                    Title = "Game Title 0",
                    Description = "This is a decent game",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                },
                new GamesModelDTO
                {
                    Id = 1,
                    Title = "Game title 1",
                    Description = "This is the game and its super cool.",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                },
                new GamesModelDTO
                {
                    Id = 2,
                    Title = "Game title 2",
                    Description = "This is the game which is very nice.",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                }
            };

            return gamesModelList;

        }

        public GamesModelDTO GetSingleGame(int gameId) //DBTest Done - Need to implement unit test
        {

            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>
            {
                new GamesModelDTO
                {
                    Id = 0,
                    Title = "Game Title 0",
                    Description = "This is a decent game",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                },
                new GamesModelDTO
                {
                    Id = 1,
                    Title = "Game title 1",
                    Description = "This is the game and its super cool.",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                },
                new GamesModelDTO
                {
                    Id = 2,
                    Title = "Game title 2",
                    Description = "This is the game which is very nice.",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                }
            };

            switch (gameId)
            {
                case 0:
                    return gamesModelList[0];
                case 1:
                    return gamesModelList[1];
                case 2:
                    return gamesModelList[2];
                default:
                    return new GamesModelDTO();
            }            
        }

        public GamesModelDTO GetSingleGameForUserById(int gameId, int userId) //DBTest Done - Need to implement unit test
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>
            {
                new GamesModelDTO
                {
                    Id = 0,
                    Title = "Game Title 0",
                    Description = "This is a decent game",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096",
                    Owned = false,
                    Completed = false,
                    Interested = false
                },
                new GamesModelDTO
                {
                    Id = 1,
                    Title = "Game title 1",
                    Description = "This is the game and its super cool.",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096",
                    Owned = false,
                    Completed = false,
                    Interested = false
                }
            };

            if(gameId == 0 && userId == 0)
            {
                return gamesModelList[0];
            }
            else if (gameId == 1 && userId == 0)
            {
                return gamesModelList[1];
            }
            else
            {
                return new GamesModelDTO();
            }
        }

        public bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId) // DBTest Done - Need to implement unit test
        {
            GamesModelDTO gamesModelDTO = new GamesModelDTO
            {
                Id = 1,
                Title = "The title",
                Description = "The description",
                HeaderUrl = "www.link.com",
                Owned = false,
                Completed = false,
                Interested = false
            };

            if(gameId == 0 && userId == 0)
            {
                if(updateWith == true)
                {
                    switch (fieldToUpdate)
                    {
                        case "owned":
                            if (gamesModelDTO.Owned)
                                return true;
                            return false;

                        case "completed":
                            if (gamesModelDTO.Completed)
                                return true;
                            return false;
                        case "interested":
                            if (gamesModelDTO.Interested)
                                return true;
                            return false;
                        default:
                            return false;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public bool IfGameExists(int gameId) // DBTest Done - Need to implement unit test
        {
            if(gameId == 1 || gameId == 2)
            {
                return true;
            }

            return false;
        }

        public bool IfNameAlreadyExists(string title) // DBTest Done - Need to implement unit test
        {
            
            if(title == "alreadyExists")
            {
                return true;
            }

            return false;
        }
    }
}
