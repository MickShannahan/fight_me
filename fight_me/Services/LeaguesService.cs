using System.Collections.Generic;
using fight_me.Models;
using fight_me.Repositories;

namespace fight_me.Services
{
  public class LeaguesService
    {
        private readonly LeaguesRepo _repo;

    public LeaguesService(LeaguesRepo repo)
    {
      _repo = repo;
    }

    internal List<GameLeague> GetAccountLeagues(string id)
    {
      return _repo.GetAccountLeagues(id);
    }
  }
}