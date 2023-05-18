using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Core.BLL
{
    public interface IGenericService<T> where T: class,IBaseEntity,new() 
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
