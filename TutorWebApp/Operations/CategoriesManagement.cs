using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorWebApp.Models;

namespace TutorWebApp.Operations
{
    public class CategoriesManagement
    {
        public static List<Category> categories = new List<Category>();

        public static List<Category> GetCategories()
        {
            categories = DatabaseOperations.FetchAllCategories();
            return categories;
        }
        public static Category GetCategoryById(int id)
        {
            Category category = new Category();
            foreach (Category x in categories)
            {
                if (x.Id == id) { category = x; break; }
            }
            return category;
        }
        public static void RemoveRequest(int id)
        {
            Category request = GetCategoryById(id);
           // DatabaseOperations.RemoveCategory(GetCategoryById(id));
            categories.Remove(request);
            
        }
       
    }
}