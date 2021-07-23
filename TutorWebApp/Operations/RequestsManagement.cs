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
        public static List<Requests> requests = new List<Requests>();

        public static List<Requests> GetRequests()
        {
            requests = DatabaseOperations.FetchAllRequests();
            return requests;
        }
        public static Requests GetRequestById(int id)
        {
            Requests request = new Requests();
            foreach (Requests x in requests)
            {
                if (x.Id == id) { request = x; break; }
            }
            return request;
        }
        public static void RemoveRequest(int id)
        {
            Requests request = GetRequestById(id);
            DatabaseOperations.RemoveRequest(GetRequestById(id));
            requests.Remove(request);
            
        }
       
    }
}