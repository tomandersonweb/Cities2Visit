using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Cities2Visit.Web.ViewModels;
using Newtonsoft.Json;

namespace Cities2Visit.Web.Repositories
{
    public class InMemoryCitiesRepository : ICitiesRepository
    {
        private MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(6000));
        private IMemoryCache _cache;
        private string _key = "cities";
        private string _defaultCities = @"[
                  {
                                'City': 'Manchester',
                    'Country': 'UK',
                    'Attractions': ['football', 'bars']
                },
                  {
                    'City': 'Liverpool',
                    'Country': 'UK',
                    'Attractions': ['football', 'bars', 'music']
                },  
                  {
                    'City': 'York',
                    'Country': 'UK',
                    'Attractions': ['city walls', 'cathedral']
                  },
                  {
                    'City': 'Las Vegas',
                    'Country': 'USA',
                    'Attractions': ['casinos','Grand Canyon','shows']
                  },
                  {
                    'City': 'Beijing',
                    'Country': 'China',
                    'Attractions': ['Great Wall of China', 'Forbidden City']
                  }
                ]";

        private List<CityViewModel> _cities;

        public InMemoryCitiesRepository(IMemoryCache memoryCache)
        {
            _cache = memoryCache;

            if (!_cache.TryGetValue(_key, out _cities))
            {
                var defaultCities = JsonConvert.DeserializeObject<List<CityViewModel>>(_defaultCities);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(6000));
                _cache.Set("cities", defaultCities, cacheEntryOptions);

                _cities = defaultCities;
            }
        }
        public List<CityViewModel> GetAllCities()
        {
            return _cities;
        }

        public CityViewModel GetCityByName(string name)
        {
            var city = _cities.Where(x => x.City?.ToLower() == name.ToLower()).SingleOrDefault();
            return city;
        }

        public void AddCity(CityViewModel city)
        {
            _cities.Add(city);
            _cache.Set("cities", _cities, cacheOptions);
        }

        public void EditCity(CityViewModel city)
        {
            var cityToUpdate = _cities.Where(x => x.City?.ToLower() == city.City.ToLower()).SingleOrDefault();

            if (cityToUpdate != null)
            {
                cityToUpdate.City = city.City;
                cityToUpdate.Attractions = city.Attractions;
                cityToUpdate.Country = city.Country;
                cityToUpdate.Visited = city.Visited;
            }
            _cache.Set("cities", _cities, cacheOptions);
        }

        public void DeleteCity(string cityName)
        {
            var cityToRemove = _cities.Where(x => x.City?.ToLower() == cityName.ToLower()).SingleOrDefault();

            if (cityToRemove != null)
                _cities.RemoveAt(_cities.IndexOf(cityToRemove));

            _cache.Set("cities", _cities, cacheOptions);
        }

    }
}
