using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tutor.Models
{
    public class Requests
    {

        public int Id { get; set; }
        public int RequestorId { get; set; }
        public string Title { get; set; }
        public int Category { get; set; }
        public string Details { get; set; }
        public int Price { get; set; }
        public int TutorID { get; set; }

        public Requests(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            RequestorId = Convert.ToInt32(reader["RequestorId"]);
            Title = reader["Title"].ToString();
            Category = Convert.ToInt32(reader["Category"]);
            Details = reader["Details"].ToString();
            Price = Convert.ToInt32(reader["Price"]);
            TutorID = Convert.ToInt32(reader["TutorID"]);

        }
        public Requests()
        { }

    }


}
