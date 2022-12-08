using fight_me.Repositories;

namespace fight_me.Services
{
  public class MatchesService
    {
        MatchesRepository _repo;

    public MatchesService(MatchesRepository repo)
    {
      _repo = repo;
    }


  }
}