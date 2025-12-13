using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using N9.Data;
using N9.Models;
using N9.Repositories.Interfaces;

namespace N9.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category GetById(int id)
        {
            var dt = DatabaseContext.ExecuteQuery(
                "SELECT * FROM Categories WHERE Id = @id",
                new SQLiteParameter("@id", id));
            
            if (dt.Rows.Count == 0) return null;
            return MapCategory(dt.Rows[0]);
        }

        public List<Category> GetAll()
        {
            return GetAllCategories();
        }

        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            var dt = DatabaseContext.ExecuteQuery("SELECT * FROM Categories ORDER BY Name");
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(MapCategory(row));
            }
            return categories;
        }

        public int Add(Category entity)
        {
            return DatabaseContext.ExecuteInsertAndGetId(
                "INSERT INTO Categories (Name, Icon) VALUES (@name, @icon)",
                new SQLiteParameter("@name", entity.Name),
                new SQLiteParameter("@icon", entity.Icon ?? ""));
        }

        public bool Update(Category entity)
        {
            DatabaseContext.ExecuteNonQuery(
                "UPDATE Categories SET Name = @name, Icon = @icon WHERE Id = @id",
                new SQLiteParameter("@name", entity.Name),
                new SQLiteParameter("@icon", entity.Icon ?? ""),
                new SQLiteParameter("@id", entity.Id));
            return true;
        }

        public bool Delete(int id)
        {
            DatabaseContext.ExecuteNonQuery("DELETE FROM Categories WHERE Id = @id", new SQLiteParameter("@id", id));
            return true;
        }

        private Category MapCategory(DataRow row)
        {
            return new Category
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                Icon = row["Icon"]?.ToString()
            };
        }
    }
}
