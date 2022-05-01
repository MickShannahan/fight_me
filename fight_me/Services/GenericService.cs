using System;
using System.Collections.Generic;
using fight_me.Interfaces;
using fight_me.Repositories;

namespace fight_me.Services
{
  public class GenericService
    {
        private Dictionary<string, IRepo<object>> repos = new Dictionary<string, IRepo<object>>();
        

    public GenericService(SystemsRepository srepo,  CategoriesRepository crepo, GamesRepository grepo)
    {
        repos.Add("games", grepo);
        repos.Add("systems", srepo);
        repos.Add("categories", crepo);
    }

    internal List<object> GetAll(string type, string search)
    {
      return repos[type].GetAll(search);
    }

    internal object GetById(string type, int id)
    {
      object data = repos[type].GetById(id);
      if(data == null){
        throw new Exception($"can't get,no {type} by that id");
      }
      return data;
    }

    internal object Create(string type, object body)
    {
      return repos[type].Create(body);
    }

    internal object Update(string type, int id, object body)
    {
      throw new Exception("not yet implemented");
    }

    internal string Delete(string type, int id)
    {
      object data = repos[type].GetById(id);
      if(data == null){
        throw new Exception($"can't delete, no {type} by that id");
      }
      return repos[type].Delete(id);
    }
  }
}