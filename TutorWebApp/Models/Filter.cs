using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorWebApp.Models
{
    public class Filter
    {
        public List<int> Cateogries { get; set; }
        public List<int> SubCateogries { get; set; }
        public List<int> Difficulties { get; set; }

    }
}
