using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorWebApp.Models;

namespace TutorWebApp.Operations
{
    public class RequestsManagement
    {
        // Creating a list with alll the requests
        public static List<Request> requests = new List<Request>();

        //Getting all the requests
        public static List<Request> GetRequests()
        {
            requests = DatabaseOperations.FetchAllRequests();
            return requests;
        }

        //Getting a specific request by Id
        public static Request GetRequestById(int id)
        {
            Request request = new Request();
            foreach (Request x in requests)
            {
                if (x.Id == id) { request = x; break; }
            }
            return request;
        }

        //Remove a request
        public static void RemoveRequest(int id)
        {
            Request request = GetRequestById(id);
            DatabaseOperations.RemoveRequest(GetRequestById(id));
            requests.Remove(request);
            
        }
       
    }
}