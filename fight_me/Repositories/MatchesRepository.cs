using System.Data;

namespace fight_me.Repositories
{
  public class MatchesRepository
    {
        IDbConnection _db;

    public MatchesRepository(IDbConnection db)
    {
      _db = db;
    }

  
  }
}