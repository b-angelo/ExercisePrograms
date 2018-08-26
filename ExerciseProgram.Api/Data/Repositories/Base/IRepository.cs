using ExerciseProgram.Models.InputModel;
using System.Collections.Generic;

namespace ExerciseProgram.Api.Data.Repositories.Base
{
    public interface IRepository<T> where T: class
    {
        T GetById(int id);
        IList<T> GetAll();
        long Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
