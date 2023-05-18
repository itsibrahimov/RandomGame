using Microsoft.Data.SqlClient;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RandomGame.DataAccess.Concrete.ADONET
{
    public class AdoGame : IGameDAL
    {
        private readonly string _conStr = "Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;";
        private readonly SqlConnection connection = new SqlConnection();
        private readonly SqlCommand command = new SqlCommand();
        public bool Add(Game entity)
        {
            using (connection)
            {
            connection.ConnectionString = _conStr;
                using (command) 
                { 
                
                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@createdTime", entity.CreatedTime);
                    command.Parameters.AddWithValue("@updatedTime", entity.UpdatedTime);
                    command.Parameters.AddWithValue("@name", entity.GameName);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Connection = connection;
                    command.CommandText = $"insert into {nameof(Game)} ({nameof(Game.Active)},{nameof(Game.Deleted)},{nameof(Game.CreatedTime)},{nameof(Game.UpdatedTime)},Name,{nameof(Game.Price)},{nameof(Game.Description)},{nameof(Game.Stock)}) values (@active,@deleted,@createdTime,@updatedTime,@name,@price,@description,@stock)";
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

        public bool Delete(Game entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Connection = connection;
                    command.CommandText = $"delete from {nameof(Game)} where {nameof(Game.Id)}=@id";
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


        public IEnumerable<Game> Get()
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;

                    command.CommandText = $"select {nameof(Game.Id)},Name,{nameof(Game.Price)},{nameof(Game.Description)}, {nameof(Game.CreatedTime)}, {nameof(Game.UpdatedTime)},{nameof(Game.Stock)} from {nameof(Game)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        yield return new Game { Id = result.GetInt32(0), GameName = result.GetString(1), Price = result.GetDecimal(2), Description = result.GetString(3), CreatedTime = result.GetDateTime(4), UpdatedTime = result.GetDateTime(5), Stock = result.GetInt32(6) };
                    }
                    connection.Close();
                    
                }

            }
        }

        public Game Get(int id)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id",id);
                    command.CommandText = $"select {nameof(Game.Id)},Name,{nameof(Game.Price)},{nameof(Game.Description)}, {nameof(Game.CreatedTime)}, {nameof(Game.UpdatedTime)},{nameof(Game.Stock)} from {nameof(Game)} where {nameof(Game.Id)} = @id";
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.Read())
                    {
                        connection.Close();
                        return new Game { Id = result.GetInt32(0), GameName = result.GetString(1), Price = result.GetDecimal(2), Description = result.GetString(3), CreatedTime = result.GetDateTime(4), UpdatedTime = result.GetDateTime(5), Stock = result.GetInt32(6) };
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }

                }

            }
        }

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            throw new NotImplementedException();
        }

        public GameDTO GetGameAndImageById(int gameId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Game entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@name", entity.GameName);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@id", entity.Id);

                    command.Connection = connection;

                    command.CommandText = $"update {nameof(Game)} set {nameof(Game.Active)} = @active,{nameof(Game.Deleted)} = @deleted,{nameof(Game.UpdatedTime)} = '{DateTime.Now}',Name = @name,{nameof(Game.Price)} = @price,{nameof(Game.Description)} = @description,{nameof(Game.Stock)} = @stock where {nameof(Game.Id)} = @id";
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
