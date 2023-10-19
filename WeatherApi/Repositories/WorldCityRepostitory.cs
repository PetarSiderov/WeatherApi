using WeatherApi.Entities;
using WeatherApi.Models;
using WeatherApi.Repositories.Interfaces;

namespace WeatherApi.Repositories
{
    public class WorldCityRepostitory : IWorldCityRepository
    {
        private WeatherContextt weatherContextt;
        public WorldCityRepostitory(WeatherContextt weatherContextt)
        {
            this.weatherContextt = weatherContextt;
        }

        public async Task<List<CitySimplier>> getAllCities()
        {
            var cities = weatherContextt.WorldCities.ToList();
            List<CitySimplier> citySimpliers= new List<CitySimplier>();
            int i = 1;
            foreach(var city in cities)
            {
                citySimpliers.Add(new CitySimplier() { Id = i++, CityName = city.CityAscii + ", " + city.Country + ", " + city.Iso2 });
            }
            return citySimpliers;
        }

        public async Task<WorldCity> getCityLangLong(string cityName)
        {
            return  weatherContextt.WorldCities.Where(s => s.CityAscii.ToLower().Equals(cityName.ToLower())).FirstOrDefault();
        }
    }
}
