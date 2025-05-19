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

        public int GetNumberOfPlayersWithoutAmount()
        {
            return _playersContext.Players.Where(p => p.Amount == 0).Count();
        }

        public int GetSumOfAllAmount()
        {
            return (int)_playersContext.Players.Sum(p => p.Amount);
        }

        public async Task AddPlayer(Player p)
        {
            if(p.Id == null)
            {
                var newId = _playersContext.Players.Max(p => p.Id);
                p.Id = newId;
            }

            if (!_playersContext.Players.Any(pl => pl.Id == p.Id))
            {
                _playersContext.Players.Add(p);
                await _playersContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Már van ilyen id");
            }
        }

        public int NextId()
        {
            return (int)_playersContext.Players.Max(p => p.Id);
        }

        public int Legalabb10K()
        {
            return _playersContext.Players.Where(p => p.Amount >= 10000).Count();
        }

        public List<Player> GetAll()
        {
            return _playersContext.Players.ToList();
        }

        public async Task EditPlayer(Player player)
        {
            _playersContext.Players.Update(player);
            await _playersContext.SaveChangesAsync();
        }

        public async Task DeleteIfNoAmount(Player player)
        {
            if (player.Amount <= 0)
            {
                _playersContext.Players.Remove(player);
                await _playersContext.SaveChangesAsync();
            }
        }

    }
}
