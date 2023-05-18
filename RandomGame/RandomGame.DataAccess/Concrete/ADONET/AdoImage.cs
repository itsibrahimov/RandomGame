using Microsoft.Data.SqlClient;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Concrete.ADONET
{
    internal class AdoImage : IimageDAL
    {
        private readonly string _conStr = "Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;";
        private readonly SqlConnection connection = new SqlConnection();
        private readonly SqlCommand command = new SqlCommand();
        public bool Add(Image entity)
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
                    command.Parameters.AddWithValue("@imageUrl", entity.ImageURL);

                    command.Connection = connection;
                    command.CommandText = $"insert into {nameof(Image)} ({nameof(Image.Active)},{nameof(Image.Deleted)},{nameof(Image.CreatedTime)},{nameof(Image.UpdatedTime)},{nameof(Image.GameID)},{nameof(Image.ImageURL)}) values (@active,@deleted,@createdTime,@updatedTime,@gameId,@imageUrl)";
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

        public bool Delete(Image entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@id", entity.Id);

                    command.Connection = connection;
                    command.CommandText = $"delete from {nameof(Image)} where {nameof(Image.Id)} = @id";
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

        public IEnumerable<Image> Get()
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;

                    command.CommandText = $"select {nameof(Image.Id)},{nameof(Image.Active)},{nameof(Image.Deleted)}, {nameof(Image.CreatedTime)}, {nameof(Image.UpdatedTime)},{nameof(Image.GameID)},{nameof(Image.ImageURL)} from {nameof(Image)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        yield return new Image { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), CreatedTime = result.GetDateTime(3), UpdatedTime = result.GetDateTime(4), GameID = result.GetInt32(5), ImageURL = result.GetString(6) };
                    }
                    connection.Close();

                }

            }
        }

        public Image Get(int id)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = $"select {nameof(Image.Id)},{nameof(Image.Active)},{nameof(Image.Deleted)}, {nameof(Image.CreatedTime)}, {nameof(Image.UpdatedTime)},{nameof(Image.GameID)},{nameof(Image.ImageURL)} from {nameof(Image)} where {nameof(Image.Id)} = @id";
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.Read())
                    {
                        connection.Close();
                        return new Image { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), CreatedTime = result.GetDateTime(3), UpdatedTime = result.GetDateTime(4), GameID = result.GetInt32(5), ImageURL = result.GetString(6) };
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                    

                }

            }
        }

        public bool Update(Image entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@imageUrl", entity.ImageURL);
                    command.Parameters.AddWithValue("@id", entity.Id);

                    command.Connection = connection;
                    command.CommandText = $"update {nameof(Image)} set {nameof(Image.Active)}=@active,{nameof(Image.Deleted)}=@deleted,{nameof(Image.UpdatedTime)}='{DateTime.Now}',{nameof(Image.GameID)}=@gameId,{nameof(Image.ImageURL)}=@imageUrl";
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
