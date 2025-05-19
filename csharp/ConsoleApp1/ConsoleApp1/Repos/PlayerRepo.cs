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
            return _playersContext.Players.Where(p=>p.GetAmount() > 0).ToList();
        }

        public int GetSumOfAllAmount()
        {
            return _playersContext.Players.Sum(p => p.GetAmount());
        }
    }
}
