using fight_me.Services;
using Microsoft.AspNetCore.Mvc;

namespace fight_me.Controllers
{
  [Route("[controller]")]
    public class MatchesController : ControllerBase
    {
      MatchesService _mService;

    public MatchesController(MatchesService mService)
    {
      _mService = mService;
    }
  }

  
}