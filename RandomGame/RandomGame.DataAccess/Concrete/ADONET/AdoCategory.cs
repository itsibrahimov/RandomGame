using Microsoft.Data.SqlClient;
using RandomGame.DataAccess.Abstract;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RandomGame.DataAccess.Concrete.ADONET
{
    internal class AdoCategory : ICategoryDAL
    {
        private readonly string _conStr = "Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;";
        private readonly SqlConnection connection = new SqlConnection();
        private readonly SqlCommand command = new SqlCommand();
        public bool Add(Category entity)
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
                    command.Parameters.AddWithValue("@name", entity.CategoryName);

                    command.Connection = connection;

                    command.CommandText = $"insert into {nameof(Category)} ({nameof(Category.Active)},{nameof(Category.Deleted)},{nameof(Category.CreatedTime)},{nameof(Category.UpdatedTime)},Name) values (@active,@deleted,@createdTime,@updatedTime,@name)";
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

        public bool Delete(Category entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Connection = connection;
                    command.CommandText = $"delete from {nameof(Category)} where {nameof(Category.Id)}=@id";
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

        public IEnumerable<Category> Get()
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;

                    command.CommandText = $"select {nameof(Category.Id)},Name, {nameof(Category.CreatedTime)}, {nameof(Category.UpdatedTime)},{nameof(Category.Active)},{nameof(Category.Deleted)} from {nameof(Category)}";
                    connection.Open();
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        yield return new Category { Id = result.GetInt32(0), CategoryName = result.GetString(1), CreatedTime = result.GetDateTime(2), UpdatedTime = result.GetDateTime(3), Active = result.GetBoolean(4), Deleted = result.GetBoolean(5) };
                    }
                    connection.Close();

                }

            }
        }

        public Category Get(int id)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = $"select {nameof(Category.Id)},Name, {nameof(Category.CreatedTime)}, {nameof(Category.UpdatedTime)},{nameof(Category.Active)},{nameof(Category.Deleted)} from {nameof(Category)} where {nameof(Category.Id)} = @id";
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.Read())
                    {
                        connection.Close();
                        return new Category { Id = result.GetInt32(0), CategoryName = result.GetString(1), CreatedTime = result.GetDateTime(2), UpdatedTime = result.GetDateTime(3), Active = result.GetBoolean(4), Deleted = result.GetBoolean(5) };
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                   

                }

            }
        }

        public bool Update(Category entity)
        {
            using (connection)
            {
                connection.ConnectionString = _conStr;
                using (command)
                {

                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@name", entity.CategoryName);
                    command.Parameters.AddWithValue("@id", entity.Id);

                    command.Connection = connection;

                    command.CommandText = $"update {nameof(Category)} set {nameof(Category.Active)} = @active,{nameof(Category.Deleted)} = @deleted,{nameof(Category.UpdatedTime)} = '{DateTime.Now}',Name = @name where {nameof(Category.Id)} = @id";
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
