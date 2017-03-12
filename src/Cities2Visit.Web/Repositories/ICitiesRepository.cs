using Cities2Visit.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities2Visit.Web.Repositories
{
    public interface ICitiesRepository
    {
        List<CityViewModel> GetAllCities();

        CityViewModel GetCityByName(string city);

        void EditCity(CityViewModel city);

        void AddCity(CityViewModel city);

        void DeleteCity(string cityName);
    }
}
