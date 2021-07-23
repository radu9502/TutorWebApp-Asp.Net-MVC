using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TutorWebApp.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public SubCategory(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            CategoryId = Convert.ToInt32(reader["CategoryId"]);
            Name = reader["Name"].ToString();
            Visibility = Convert.ToInt32(reader["Visibility"]);
            

        }
        public SubCategory() { }
    }
}
