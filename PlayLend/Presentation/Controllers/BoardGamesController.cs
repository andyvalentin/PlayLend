using PlayLend.Domain;
using PlayLend.Services;
using PlayLend.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayLend.Presentation.Controllers
{
    public class BoardGamesController : ApiController
    {
        private BoardGameService _bgService;

        public BoardGamesController(BoardGameService bgService) {
            _bgService = bgService;
        }

        [Authorize]
        [HttpGet]
        [Route("api/boardgamelist")]
        public IList<BoardGameDTO> AllBoardGames() {
            return _bgService.AllBoardGames();
        }

        [Authorize]
        [HttpGet]
        [Route("api/userprofile")]
        public IList<BoardGameDTO> OwnerBoardGames()
        {
            return _bgService.OwnerBoardGames(User.Identity.Name);
        }

        [Authorize]
        [HttpPost]
        [Route("api/userprofile/addgame")]
        public IHttpActionResult AddGame(BoardGame boardgame) {
            if (ModelState.IsValid)
            {
                _bgService.AddGame(boardgame.Name, boardgame.PlayerRange, boardgame.Description, User.Identity.Name);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpDelete]
        [Route("api/userprofile/games/{id}")]
        public IHttpActionResult DeleteGame(int id) {
            if (ModelState.IsValid)
            {
                _bgService.DeleteGame(id);
                return Ok();
            }
            return BadRequest();
        }


    }
}
