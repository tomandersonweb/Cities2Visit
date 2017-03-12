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
        // GET api/cities
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_citiesRepository.GetAllCities());
        }

        // GET api/values/5
        [HttpGet("{cityName}")]
        public IActionResult Get(string cityName)
        {
            return Ok(_citiesRepository.GetCityByName(cityName));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CityViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _citiesRepository.AddCity(value);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{cityName}")]
        public IActionResult Put(string cityName, [FromBody]CityViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _citiesRepository.EditCity(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{cityName}")]
        public IActionResult Delete(string cityName)
        {
            _citiesRepository.DeleteCity(cityName);
            return Ok();
        }
    }
}
