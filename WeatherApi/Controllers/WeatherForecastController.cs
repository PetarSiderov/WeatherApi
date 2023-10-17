using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WeatherApi.Repositories.Interfaces;
using WeatherApi.Services.Interface;

namespace WeatherApi.Controllers
{
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

        [HttpPost("WeatherSearch")]
        public async Task<IActionResult> SearchWeather([FromQuery] string city)
        {
            try
            {
                var response = await worldCityRepository.getCityLangLong(city);
                var result = await weatherService.getCurrentWeather((double)response.Lat, (double)response.Lng);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}