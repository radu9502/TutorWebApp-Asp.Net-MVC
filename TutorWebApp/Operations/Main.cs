using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Operations;
using Tutor.Models;

namespace Bazar.Operations
{
    public class Main
    {
        public static List<Requests> requests = new List<Requests>();

        public static List<Requests> GetCars()
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
        public static void RemoveCar(int id)
        {
            Requests request = GetRequestById(id);
            DatabaseOperations.RemoveRequest(request);
            requests.Remove(request);
            
        }
       
    }
}