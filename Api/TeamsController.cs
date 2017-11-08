using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Mvc.Dal.Interfaces;
using Mvc.Models;

namespace Mvc.Controllers.Api
{

    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamRepository _repo;

        public TeamsController(ITeamRepository teamRepository)
        {
            _repo = teamRepository;
        }

        [HttpGet]
        public List<Team> Get()  {
            var teams = _repo.GetTeams();
            
            return  teams;
        } 

        [HttpGet]
        [Route("{id}")] 
        public Team GetTeam(int id) {
            var team = _repo.GetTeam(id);

            return team;
        }

        [HttpGet]
        [Route("{id}/players")]
        public List<Player> GetTeamPlayers(int id) {
            var players = _repo.GetTeamPlayers(id);

            return players;
        }
    }
}