﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TutorWebApp.Models;
using TutorWebApp;

namespace TutorWebApp.Operations
{
    
    public class DatabaseOperations
    {
        #region Requests
        public static List<Requests> FetchAllRequests()
        {
            List<Requests> allRequests = new List<Requests>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Startup.ConnectionString;

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Requests", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Requests request = new Requests(reader);
                            allRequests.Add(request);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return allRequests;
        }




        public static void InsertRequest(Requests request)
        {
            string query = "INSERT INTO Requests (RequestorId, Title, Category, Details, Price, TutorID) VALUES (@RequestorId, @Title, @Category, @Details, @Price, @TutorID);";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@Id", request.Id }, { "@RequestorId", request.RequestorId }, { "@Title", request.Title }, { "@Category", request.Category }, { "@Details", request.Details }, { "@Price", request.Price }, { "@TutorID", request.TutorID } };
            ExecuteCommand(query, parameters);
        }



        public static void RemoveRequest(Requests request)
        {
            string query = "DELETE FROM Requests WHERE Id = @Id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@Id", request.Id } };
            ExecuteCommand(query, parameters);
        }





        public static void ExecuteCommand(string query, Dictionary<string, object> par)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Startup.ConnectionString;
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    foreach (KeyValuePair<string, object> entry in par)
                    {
                        command.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
        #endregion
        #region Categories
        public static List<Category> FetchAllCategories()
        {
            List<Category> allCategories = new List<Category>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Startup.ConnectionString;

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE Visibility = 1", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category(reader);
                            allCategories.Add(category);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return allCategories;
        }
        #endregion
    }
}