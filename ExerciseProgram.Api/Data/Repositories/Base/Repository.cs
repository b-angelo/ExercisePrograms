﻿using System;
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
        private readonly string _connectionString = ConfigurationManager.AppSettings["ExerciseProgramDbConnection"];
        private readonly int _dbTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["Db.Timeout"]);

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Get<T>(id, commandTimeout: _dbTimeout);

                return result;
            }
        }

        public IList<T> GetAll(PagingInputModel pagingInputModel, string orderBy, string orderDirection)
        {          
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.GetAll<T>(commandTimeout: _dbTimeout).ToList();

                if (result.Count <= pagingInputModel.PageSize)
                {
                    if (orderBy == "asc")
                    {
                        return result; // ToDo: Order ascending
                    }
                    else
                    {
                        return result; // ToDo Order descending
                    }                    
                }
                else
                {
                    var skip = pagingInputModel.PageNumber * pagingInputModel.PageSize - pagingInputModel.PageSize;

                    return result.Skip(skip).Take(pagingInputModel.PageSize).ToList();
                }
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