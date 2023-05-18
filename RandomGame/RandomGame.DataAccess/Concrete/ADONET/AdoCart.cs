using Microsoft.Data.SqlClient;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.DTO;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.ADONET
{
    internal class AdoCart : ICartDAL
    {
        private readonly string _conStr = "Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;";
        private readonly SqlConnection connection = new SqlConnection();
        private readonly SqlCommand command = new SqlCommand();
        public bool Add(Cart entity)
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
                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@appUserId", entity.AppUserId);
                    command.Parameters.AddWithValue("@quantity", entity.Quantity);
                    command.Connection = connection;
                    command.CommandText = $"insert into {nameof(Cart)} ({nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.CreatedTime)},{nameof(Cart.UpdatedTime)},{nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)}) values (@active,@deleted,@createdTime,@updatedTime,@gameId,@appUserId,@quantity)";
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

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cart entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Connection = connection;
                    command.CommandText = $"Delete From {nameof(Cart)} where {nameof(Cart.Id)} = @id";
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

        public void DeleteCartById(int userId, int gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> Get()
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;

                    command.CommandText = $"select {nameof(Cart.Id)},{nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.UpdatedTime)}, {nameof(Cart.CreatedTime)}, {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        yield return new Cart { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), UpdatedTime = result.GetDateTime(3), CreatedTime = result.GetDateTime(4),  GameID = result.GetInt32(5), AppUserId = result.GetInt32(6),Quantity=result.GetInt32(7) };
                    }
                    connection.Close();
                }

            }
        }

        public Cart Get(int id)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id",id);
                    command.CommandText = $"select {nameof(Cart.Id)},{nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.UpdatedTime)}, {nameof(Cart.CreatedTime)}, {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.Read())
                    {
                        connection.Close();
                        return new Cart { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), UpdatedTime = result.GetDateTime(3), CreatedTime = result.GetDateTime(4), GameID = result.GetInt32(5), AppUserId = result.GetInt32(6), Quantity = result.GetInt32(7) };
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                    
                }

            }
        }

        public IEnumerable<CartDTO> GetCartByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cart entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@appUserId", entity.AppUserId);
                    command.Parameters.AddWithValue("@quantity", entity.Quantity);
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Connection = connection;
                    command.CommandText = $"update {nameof(Cart)} set ({nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.UpdatedTime)},{nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)}) values (@active,@deleted,'{DateTime.Now}',@gameId,@appUserId,@quantity) where {nameof(Cart.Id)} = @id";
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
