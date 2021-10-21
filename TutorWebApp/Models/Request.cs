﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TutorWebApp.Models
{
    public class Request
    {

        public int Id { get; set; }
        public int RequestorId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public int Price { get; set; }
        public int TutorID { get; set; }
        public int Dificulty { get; set; } // generala/liceu/facultate
        public int PublishDate { get; set; }
        public int Visibility { get; set; }
        public Request(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            RequestorId = Convert.ToInt32(reader["RequestorId"]);
            Title = reader["Title"].ToString();
            CategoryId = Convert.ToInt32(reader["Category"]);
            Details = reader["Details"].ToString();
            Price = Convert.ToInt32(reader["Price"]);
            TutorID = Convert.ToInt32(reader["TutorID"]);
            Dificulty = Convert.ToInt32(reader["Dificulty"]);
            PublishDate = Convert.ToInt32(reader["PublishDate"]);
            Visibility = Convert.ToInt32(reader["Visibility"]);
        }
        public Request()
        { }

    }


}