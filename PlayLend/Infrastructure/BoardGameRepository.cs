using PlayLend.Domain;
using PlayLend.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlayLend.Infrastructure
{
    public class BoardGameRepository
    {
        private ApplicationDbContext _db;

        public BoardGameRepository(DbContext db) {
            _db = (ApplicationDbContext)db;
        }

        public IQueryable<BoardGame> AllBoardGames() {
            return from g in _db.BoardGames
                   .Include(u => u.Owner)
                   select g;
        }

        public void AddGame(BoardGame boardgame) {
            _db.BoardGames.Add(boardgame);
            _db.SaveChanges();
        }

        public void DeleteGame(int id) {
            var game = _db.BoardGames.Find(id);
            _db.BoardGames.Remove(game);
            _db.SaveChanges();
        }
    }
}