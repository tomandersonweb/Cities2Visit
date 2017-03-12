using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities2Visit.Web.ViewModels
{
    public class CityViewModel
    {
        public string City { get; set; }

        public string Country { get; set; }

        public List<string> Attractions { get; set; }

        public bool Visited { get; set; }
    }
}
