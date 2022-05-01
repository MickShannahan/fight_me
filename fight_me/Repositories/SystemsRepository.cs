using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using fight_me.Interfaces;
using fight_me.Models;

namespace fight_me.Repositories
{
  public class SystemsRepository : IRepo<Object>
    {
        private readonly IDbConnection _db;

    public SystemsRepository(IDbConnection db)
    {
      _db = db;
    }
       public new List<object> GetAll(string search)
    {
      search = "%" + search +"%";
      string sql = @"
        SELECT 
        *
        FROM systems
        WHERE name LIKE @search;
      ";
      return _db.Query<object>(sql, new {search}).ToList();
    }

    public new object GetById(int id)
    {
        string sql = @"
        SELECT 
        *
        FROM systems
        WHERE id = @id
      ";
      return _db.Query<object>(sql, new {id}).FirstOrDefault();
    }
    public new object Create(object body)
    {
      GameSystem gameSystem = (GameSystem)body;
      string sql = @"
      INSERT INTO systems
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSTER_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, gameSystem);
      gameSystem.Id = id;
      return body;
    }

    public new object Update(int id, object body)
    {
      GameSystem gameSystem = (GameSystem)body;
      gameSystem.Id = id;
      string sql = @" 
      UPDATE SET
      name = @Name
      WHERE id = @Id;
      ";
       int rows = _db.Execute(sql, gameSystem);
      if(rows > 0){
        return body;
      }
      throw new Exception("could not edit category in sql");
    }

    public new string Delete(int id)
    {
      object original = this.GetById(id);
      GameSystem gameSystem = (GameSystem)original;
      string sql = @"
      DELETE FROM systems WHERE id = @Id LIMIT 1;
      ";
      int rows = _db.Execute(sql, new {id});
      if(rows > 0){
        return $"GameSystem {gameSystem.Name} Deleted";
      }
      throw new Exception("could not delete category in sql");
    }
  }
}