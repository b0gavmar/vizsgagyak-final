using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repos
{
    public class PlayerRepo
    {
        private readonly PlayersContext _playersContext = new PlayersContext();

        public List<Player> GetNumberOfPlayersWithAmount()
        {
            return _playersContext.Players.Where(p=>p.Amount > 0).ToList();
        }

        public List<Player> GetNumberOfPlayersWithoutAmount()
        {
            return _playersContext.Players.Where(p => p.Amount == 0).ToList();
        }

        public int GetSumOfAllAmount()
        {
            return _playersContext.Players.Sum(p => p.Amount);
        }

        public void AddPlayer(Player p)
        {
            if (!_playersContext.Players.Any(pl => pl.Id == p.Id))
            {
                _playersContext.Players.Add(p);
                _playersContext.SaveChanges();
            }
            else
            {
                throw new Exception("Már van ilyen id");
            }
        }

        public int Legalabb10K()
        {
            return _playersContext.Players.Where(p => p.Amount >= 10000).Count();
        }
    }
}
