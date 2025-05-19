using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly JatekokContext _context = new();

        [HttpGet("/players/number")]
        public async Task<IActionResult> GetNumberOfPlayers()
        {
            return Ok(await _context.Players.CountAsync());
        }

        [HttpGet("/players/amount/{min_amount}")]
        public async Task<IActionResult> GetPlayersWithMoreThan([FromRoute] int min_amount)
        {
            return Ok(await _context.Players.Where(p=>p.Amount>=min_amount).ToListAsync());
        }

        [HttpGet("/games/sort")]
        public async Task<IActionResult> GetSortedGames()
        {
            return Ok(await _context.Plays
                .GroupBy(p => p.GameId)
                .Select(g => new { gameId = g.Key, amountsum = g.Sum(x => x.Amount) })
                .Join(_context.Games, p => p.gameId, g => g.Id, (p, g) => new { name = g.Game1, amount = (int)p.amountsum }) //a new-t na hagyjam le pls
                .ToListAsync());
        }

        [HttpGet("/games/player/{player_id}")]
        public async Task<IActionResult> GetGamesPlayedByPlayer([FromRoute] int player_id)
        {
            return Ok(await _context.Plays
                .Join(_context.Players, play=>play.PlayerId, p=>p.Id, (play,p) => new { jatek= play, jatekos = p})
                .Join(_context.Games, p=>p.jatek.GameId, g=> g.Id, (p,g)=> new {jatek = p.jatek, jatekosId = p.jatekos.Id, game = g })
                .Where(g=> g.jatekosId == player_id)
                .Select(s=> new {game = s.game, jatek = s.jatek})
                .GroupBy(p=>p.game.Id)
                .Select(s=>new {jatekNev = s.First().game.Game1, elkoltott = s.Sum(x=>x.jatek.Amount)})
                .ToListAsync());
        }

        [HttpDelete("/players/{id}")]
        public async Task<IActionResult> DeletePlayerById([FromRoute] int id)
        {
            try
            {
                var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
                if(player != null)
                {
                    _context.Players.Remove(player);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
