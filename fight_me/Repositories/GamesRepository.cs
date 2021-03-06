using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using fight_me.Interfaces;
using fight_me.Models;

namespace fight_me.Repositories
{
  public class GamesRepository : IRepo<object>
    {
        private readonly IDbConnection _db;

    public GamesRepository(IDbConnection db)
    {
      _db = db;
    }


    public new List<object> GetAll(string search)
    {
      search = "%" + search +"%";
      string sql = @"
     SELECT
      g.*,
      COUNT(m.id) AS popularity
    FROM games g
      LEFT JOIN matches m on m.gameId = g.id
    WHERE title LIKE @search OR subtitle LIKE @search OR REPLACE(title, ' ', '') LIKE @search OR REPLACE(subtitle, ' ', '') LIKE @search
    GROUP BY g.id
    ORDER BY popularity DESC;
    ";
      return _db.Query<object>(sql, new {search}).ToList();
    }

    public new List<object> GetAll(int? gameId)
    {
      string sql = @"
        SELECT 
        *
        FROM games
        WHERE gameId = @gameId;
      ";
      return _db.Query<object>(sql, new {gameId}).ToList();
    }

    internal List<Game> GetByCategory(int? categoryId)
    {
      string sql = @"
      SELECT
      g.*,
      COUNT(m.id) AS popularity
      FROM gameCategories gc
        JOIN games g ON gc.gameId = g.id
        LEFT JOIN matches m on m.gameId = g.id
      WHERE gc.categoryId = @categoryId
      GROUP BY g.id
      ORDER BY popularity DES;     
      ";
      return _db.Query<Game>(sql, new {categoryId}).ToList();
    }
     internal List<Game> GetByCategory(string category)
    {
      category = "%" + category + "%";
      string sql = @"
      SELECT
      g.*,
      COUNT(m.id) AS popularity,
      c.name
      FROM gameCategories gc
        JOIN games g ON gc.gameId = g.id
        JOIN categories c ON gc.categoryId = c.id
        LEFT JOIN matches m on m.gameId = g.id
      WHERE c.name LIKE @category OR REPLACE(c.name, ' ', '') LIKE @category
      GROUP BY g.id
      ORDER BY popularity DESC;     
      ";
      return _db.Query<Game>(sql, new {category}).ToList();
    }

    public new object GetById(int id)
    {
        string sql = @"
        SELECT 
        *
        FROM games
        WHERE id = @id
      ";
      return _db.Query<object>(sql, new {id}).FirstOrDefault();
    }
    public object Create(object body)
    {
      Game game = (Game)body;
      string sql = @"
      INSERT INTO games
      (title, subtitle, img, icon, coverImg, posterImg, colorPrimary, colorSecondary)
      VALUES
      (@Title, @Subtitle, @Img, @Icon, @CoverImg, @PosterImg, @ColorPrimary, @ColorSecondary);
      SELECT LAST_INSTER_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, game);
      game.Id = id;
      return game;
    }

    public object Update(int id, object body)
    {
      Game game = (Game)body;
      game.Id = id;
      string sql = @" 
      UPDATE SET
      title = @Title,
      subtitle = @Subtitle,
      img = @Img,
      icon = @Icon,
      coverImg = @CoverImg,
      posterImg = @PosterImg,
      colorPrimary = @ColorPrimary,
      colorSecondary = @ColorSecondary
      WHERE id = @Id;
      ";
       int rows = _db.Execute(sql, game);
      if(rows > 0){
        return game;
      }
      throw new Exception("could not edit game in sql");
    }

    public new string Delete(int id)
    {
      object original = this.GetById(id);
      Game game = (Game)original;
      string sql = @"
      DELETE FROM games WHERE id = @Id LIMIT 1;
      ";
      int rows = _db.Execute(sql, new {id});
      if(rows > 0){
        return $"Game {game.Title} Deleted";
      }
      throw new Exception("could not delete game in sql");
    }
  }


}