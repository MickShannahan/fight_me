using System.Collections.Generic;

namespace fight_me.Interfaces
{
  public interface IRepo<T>
    {
      public List<T> GetAll(string search);

      public T GetById(int id);

      public T Create(T body);

      public T Update(int id, T body);

      public string Delete(int id);
        
    }
}