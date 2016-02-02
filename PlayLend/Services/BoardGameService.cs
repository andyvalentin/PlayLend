using Microsoft.AspNet.Identity;
using PlayLend.Domain;
using PlayLend.Infrastructure;
using PlayLend.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayLend.Services
{
    public class BoardGameService
    {
        private BoardGameRepository _bgrepo;
        private ApplicationUserManager _userrepo;

        public BoardGameService(BoardGameRepository bgrepo, ApplicationUserManager userrepo)
        {
            _bgrepo = bgrepo;
            _userrepo = userrepo;
        }

        public IList<BoardGameDTO> AllBoardGames()
        {
            return (from g in _bgrepo.AllBoardGames()
                    orderby g.Name ascending
                    select new BoardGameDTO()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        PlayerRange = g.PlayerRange,
                        Description = g.Description,
                        Owner = new OwnerDTO()
                        {
                            Name = g.Owner.UserName
                        }
                    }).ToList();
        }

        public IList<BoardGameDTO> OwnerBoardGames(string username)
        {
            return (from g in _bgrepo.AllBoardGames()
                    where g.Owner.UserName == username
                    orderby g.Name ascending
                    select new BoardGameDTO()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        PlayerRange = g.PlayerRange,
                        Description = g.Description,
                        Owner = new OwnerDTO()
                        {
                            Name = g.Owner.UserName
                        }
                    }).ToList();
        }

        public void AddGame(string name, string playerRange, string description, string username)
        {
            var owner = _userrepo.FindByName(username);
            var newboardgame = new BoardGame()
            {
                Name = name,
                PlayerRange = playerRange,
                Description = description,
                Owner = owner
            };
            _bgrepo.AddGame(newboardgame);
        }

        public void DeleteGame(int id) {
            _bgrepo.DeleteGame(id);
        }
    }
}