using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamsPlayers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamsPlayers.Controllers
{
    [Route("api/TeamsController")]
    [ApiController]
    public class TeamsController : Controller
    {
        private TeamsDbContext teamsDbContext;

        public TeamsController(TeamsDbContext _teamsDbContext)
        {
            this.teamsDbContext = _teamsDbContext;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Team> GetTeams()
        {
            return teamsDbContext.Teams;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            if (teamsDbContext.Teams.Find(id) == null)
            {
                return NotFound();
            }

            return teamsDbContext.Teams.Find(id);
        }

        // POST api/<controller>
        [HttpPost]        
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            teamsDbContext.Teams.Add(team);
            await teamsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id, name = team.Name, location = team.Location, players = team.Players }, team);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            teamsDbContext.Entry(team).State = EntityState.Modified;
            await teamsDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            var todoItem = await teamsDbContext.Teams.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            teamsDbContext.Teams.Remove(todoItem);
            await teamsDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
