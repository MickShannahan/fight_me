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

    public GamesController(GamesService gs)
    {
      _gs = gs;
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
    }
}