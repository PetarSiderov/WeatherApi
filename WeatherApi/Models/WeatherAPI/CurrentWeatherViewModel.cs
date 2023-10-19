namespace WeatherApi.Models.WeatherAPI
{
    public class CurrentWeatherViewModel
    {
        public string cityName { get; set; }
        public List<Daily> dailyPrediction { get; set; }
    }

}
