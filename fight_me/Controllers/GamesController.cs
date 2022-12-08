using System.Collections.Generic;
using fight_me.Models;
using fight_me.Services;
using Microsoft.AspNetCore.Mvc;

namespace fight_me.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gs;
        private readonly LeaguesService _ls;

    public GamesController(GamesService gs, LeaguesService ls)
    {
      _gs = gs;
      _ls = ls;
    }

    [HttpGet]
     public ActionResult<List<Game>> GetByCategory(int? categoryId, string category, string search){
         try
         {
            if(categoryId != 0 && categoryId != null){
                return Ok(_gs.GetByCategory(categoryId));
            } else if (category != "" && category != null){
                return Ok(_gs.GetByCategory(category));
            }
                return Ok(_gs.GetAll(search));
         }
         catch (System.Exception e)
         {
         return BadRequest(e);
         }
     }

     [HttpGet("{id}/leaderboard")]
    public ActionResult<List<PlayerLeague>> GetLeaderboard(int id)
    {
        try
        {
            return Ok(_ls.GetLeaderboard(id));
        }
        catch (System.Exception e)
        {
            return BadRequest(e);
        }
    }
    }
}