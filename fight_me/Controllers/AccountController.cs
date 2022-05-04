using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fight_me.Models;
using fight_me.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fight_me.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly LeaguesService _lService;

    public AccountController(AccountService accountService, LeaguesService lService)
    {
      _accountService = accountService;
      _lService = lService;
    }

    [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [HttpGet("leagues")]
     public async Task<ActionResult<List<GameLeague>>> GetAccountLeagues()
     {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            return Ok(_lService.GetAccountLeagues(userInfo.Id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
     }
    }
}