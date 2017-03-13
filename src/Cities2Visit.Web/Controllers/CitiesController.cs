using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cities2Visit.Web.Repositories;
using Cities2Visit.Web.ViewModels;

namespace Cities2Visit.Web.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        ICitiesRepository _citiesRepository;

        public CitiesController(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_citiesRepository.GetAllCities());
        }

        [HttpGet("visited")]
        public IActionResult CountVisitedCities()
        {
            var count = _citiesRepository.CountVisitedCities();
            return Ok(count);
        }

        [HttpGet("{cityName}")]
        public IActionResult Get(string cityName)
        {
            return Ok(_citiesRepository.GetCityByName(cityName));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CityViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _citiesRepository.AddCity(value);
            return Ok();
        }

        [HttpPut("{cityName}")]
        public IActionResult Put(string cityName, [FromBody]CityViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _citiesRepository.EditCity(value);
            return Ok();
        }

        [HttpDelete("{cityName}")]
        public IActionResult Delete(string cityName)
        {
            _citiesRepository.DeleteCity(cityName);
            return Ok();
        }
    }
}
