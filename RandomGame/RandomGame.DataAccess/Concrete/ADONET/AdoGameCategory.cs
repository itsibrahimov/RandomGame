using Microsoft.Data.SqlClient;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RandomGame.DataAccess.Concrete.ADONET
{
    internal class AdoGameCategory : IGameCategoryDAL
    {
        private readonly string _conStr = "Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;";
        private readonly SqlConnection connection = new SqlConnection();
        private readonly SqlCommand command = new SqlCommand();
        public bool Add(GameCategory entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@categoryId", entity.CategoryID);
                    command.Connection = connection;
                    command.CommandText = $"insert into {nameof(GameCategory)} ({nameof(GameCategory.GameID)},{nameof(GameCategory.CategoryID)}) values (@gameId,@categoryId)";
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }

            }
        }

        public bool Delete(GameCategory entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@categoryId", entity.CategoryID);
                    command.Connection = connection;
                    command.CommandText = $"delete from {nameof(GameCategory)} where {nameof(GameCategory.GameID)} = @gameId and {nameof(GameCategory.CategoryID)} = @categoryId";
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }

            }
        }

        public IEnumerable<GameCategory> Get()
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;

                    command.CommandText = $"select {nameof(GameCategory.GameID)},{nameof(GameCategory.CategoryID)} from {nameof(GameCategory)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        yield return new GameCategory { GameID = result.GetInt32(0), CategoryID = result.GetInt32(1) };
                    }
                    connection.Close();

                }

            }
        }

        public GameCategory Get(int id)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@gameId", id);
                    command.CommandText = $"select {nameof(GameCategory.GameID)},{nameof(GameCategory.CategoryID)} from {nameof(GameCategory)} where {nameof(GameCategory.GameID)} = @id";
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.Read())
                    {
                        connection.Close();
                        return new GameCategory { GameID = result.GetInt32(0), CategoryID = result.GetInt32(1) };
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                    

                }

            }
        }

        public bool Update(GameCategory entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@categoryId", entity.CategoryID);
                    command.Connection = connection;
                    command.CommandText = $"update {nameof(GameCategory)} set {nameof(GameCategory.GameID)}=@gameId,{nameof(GameCategory.CategoryID)}=@categoryId where {nameof(GameCategory.GameID)} = @gameId and {nameof(GameCategory.CategoryID)} = @categoryId ";
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }

            }
        }
    }
}
