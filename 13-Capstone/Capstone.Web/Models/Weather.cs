using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecast { get; set; }
        public double LowTemp { get; set; }
        public double HighTemp { get; set; }
        public string Forecast { get; set; }
    }
}
