using System.Collections.Generic;
using fight_me.Models;
using fight_me.Repositories;

namespace fight_me.Services
{
  public class GamesService
  {
      private readonly GamesRepository _repo;

    public GamesService(GamesRepository repo)
    {
      _repo = repo;
    }
    internal List<object> GetAll(string search)
    {
      return _repo.GetAll(search);
    }

    internal List<Game> GetByCategory(int? categoryId)
    {
      return _repo.GetByCategory(categoryId);
    }
    internal List<Game> GetByCategory(string category)
    {
      return _repo.GetByCategory(category);
    }

  
  }
}