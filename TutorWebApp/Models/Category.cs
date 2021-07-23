using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TutorWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public string ImageUrl { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public Category(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            Name = reader["Name"].ToString();
            Visibility = Convert.ToInt32(reader["Visibility"]);
            ImageUrl = reader["ImageUrl"].ToString();

        }
        public Category()
        { }
    }
}
