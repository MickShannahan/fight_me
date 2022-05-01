using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using fight_me.Interfaces;
using fight_me.Models;

namespace fight_me.Repositories
{
  public class CategoriesRepository : IRepo<object>
    {
        private readonly IDbConnection _db;

    public CategoriesRepository(IDbConnection db)
    {
      _db = db;
    }

       public new List<object> GetAll(string search)
    {
      search = "%" + search +"%";
      string sql = @"
        SELECT 
        *
        FROM categories
        WHERE name LIKE @search;
      ";
      return _db.Query<object>(sql, new {search}).ToList();
    }

    public new object GetById(int id)
    {
        string sql = @"
        SELECT 
        *
        FROM categories
        WHERE id = @id
      ";
      return _db.Query<object>(sql, new {id}).FirstOrDefault();
    }
    public object Create(object body)
    {
      Category category = (Category)body;
      string sql = @"
      INSERT INTO categories
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSTER_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, category);
      category.Id = id;
      return category;
    }

    public object Update(int id, object body)
    {
      Category category = (Category)body;
      category.Id = id;
      string sql = @" 
      UPDATE SET
      name = @Name
      WHERE id = @Id;
      ";
       int rows = _db.Execute(sql, category);
      if(rows > 0){
        return category;
      }
      throw new Exception("could not edit category in sql");
    }

    public new string Delete(int id)
    {
      object original = this.GetById(id);
      Category category = (Category)original;
      string sql = @"
      DELETE FROM categories WHERE id = @Id LIMIT 1;
      ";
      int rows = _db.Execute(sql, new {id});
      if(rows > 0){
        return $"Category {category.Name} Deleted";
      }
      throw new Exception("could not delete category in sql");
    }
  }
}