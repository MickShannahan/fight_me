using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using fight_me.Models;

namespace fight_me.Repositories
{
  public class LeaguesRepo
    {
        private readonly IDbConnection _db;

    public LeaguesRepo(IDbConnection db)
    {
      _db = db;
    }

    internal List<GameLeague> GetAccountLeagues(string id)
    {
      string sql =@"
    SELECT 
        g.*,
        pl.id AS playerLeagueId,
        pl.*,
        l.*
    FROM playerleagues pl
        JOIN games g ON pl.gameId = g.id
        JOIN leagues l ON pl.rankedElo > l.minElo AND pl.rankedElo < l.maxElo
    WHERE pl.accountId = @id;
      ";
      return _db.Query<GameLeague, PlayerLeague, League,  GameLeague>(sql, (g, pl, l)=>{
          g.League = l;
          g.AccountId = pl.AccountId;
          return g;
      }, new {id}).ToList();
    }

      internal List<PlayerLeague> GetLeaderboard(int gameId)
    {
      string sql = @"
        SELECT 
          a.*, 
          l.*, 
          pl.*
        FROM playerleagues pl
          JOIN accounts a ON pl.accountId = a.id
          JOIN leagues l ON pl.elo > l.minElo AND pl.elo < l.maxElo
        WHERE pl.gameId = @gameId
        ORDER BY pl.elo DESC;
      ";
      return _db.Query<Profile, League, PlayerLeague, PlayerLeague>(sql, (p, l, pl)=>{
        pl.Account = p;
        pl.League = l;
        return pl;
      }, new {gameId}).ToList();
    }
  }
}