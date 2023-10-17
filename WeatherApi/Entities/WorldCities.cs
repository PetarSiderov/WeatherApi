using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Entities
{
    public class WorldCity
    {

        [Column("city_ascii")]
        public string CityAscii { get; set; }

        [Column("lat")]
        public double? Lat { get; set; }

        [Column("lng")]
        public double? Lng { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("iso2")]
        public string Iso2 { get; set; }

        [Column("iso3")]
        public string Iso3 { get; set; }

        [Column("capital")]
        public string Capital { get; set; }

        [Column("population")]
        public int? Population { get; set; }
    }
}
