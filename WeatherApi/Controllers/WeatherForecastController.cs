using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WeatherApi.Repositories.Interfaces;
using WeatherApi.Services.Interface;

namespace WeatherApi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWorldCityRepository worldCityRepository;
        private IWeatherService weatherService;
        public WeatherForecastController(IWorldCityRepository worldCityRepository, IWeatherService weatherService)
        {
            this.worldCityRepository = worldCityRepository;
            this.weatherService = weatherService;
        }

        [HttpGet("WeatherSearch")]
        public async Task<IActionResult> SearchWeather([FromQuery] string city)
        {
            try
            {
                var response = await worldCityRepository.getCityLangLong(city);
                var result = await weatherService.getCurrentWeather(response);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities([FromQuery] string cityName)
        {
            try
            {
                var response = await worldCityRepository.getAllCities();
                if (cityName == "all")
                {
                    return Ok(response.Take(1000).ToList());
                }
                var filtered = response.Where(s => s.CityName.ToLower().Contains(cityName.ToLower())).Take(1000).ToList(); 
                return Ok(filtered);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}