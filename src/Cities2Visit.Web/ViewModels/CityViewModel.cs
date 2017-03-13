using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cities2Visit.Web.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel() { }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Country { get; set; }

        public List<string> Attractions { get; set; }

        public bool Visited { get; set; }
    }
}
