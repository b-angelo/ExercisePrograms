using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using ExerciseProgram.Models.InputModel;

namespace ExerciseProgram.Api.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // ToDo: Create settings class
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExerciseProgramDbConnection"].ConnectionString;
        private readonly int _dbTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["Db.Timeout"]);

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var x = typeof(T);

                connection.Open();

                var result = connection.Get<T>(id, commandTimeout: _dbTimeout);

                return result;
            }
        }

        public IList<T> GetAll()
        {          
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.GetAll<T>(commandTimeout: _dbTimeout).ToList();
            }
        }

        public long Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Insert(entity, commandTimeout: _dbTimeout);

                return result;
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Update(entity, commandTimeout: _dbTimeout);

                return result;
            }
        }

        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Delete(entity, commandTimeout: _dbTimeout);

                return result;
            }
        }
    }
}