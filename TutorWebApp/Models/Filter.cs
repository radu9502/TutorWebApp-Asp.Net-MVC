using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorWebApp.Models
{
    public class Filter
    {
        public List<int> Categories { get; set; }
        public List<int> SubCategories { get; set; }
        public List<int> Difficulties { get; set; }

    }
}
