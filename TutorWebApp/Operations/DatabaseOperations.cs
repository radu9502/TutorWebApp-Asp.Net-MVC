using System;
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
        public static List<Request> FetchAllRequests()
        {
            List<Request> allRequests = new List<Request>();
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
                            Request request = new Request(reader);
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


        public static void InsertRequest(Request request)
        {
            string query = "INSERT INTO Requests (RequestorId, Title, CategoryId, Details, Price, TutorId, SubCategoryId) VALUES (@RequestorId, @Title, @CategoryId, @Details, @Price, @TutorId, @SubCategoryId);";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@Id", request.Id }, { "@RequestorId", request.RequestorId }, { "@Title", request.Title }, { "@Category", request.CategoryId }, { "@Details", request.Details }, { "@Price", request.Price }, { "@TutorId", request.TutorId }, { "@SubCategoryId", request.SubCategoryId } };
            ExecuteCommand(query, parameters);
        }

     

        public static void RemoveRequest(Request request)
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