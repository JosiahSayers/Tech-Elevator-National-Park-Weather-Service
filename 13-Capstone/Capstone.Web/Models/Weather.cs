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

        public string ForecastMessage
        {
            get
            {
                string output = "";

                if(Forecast == "snow")
                {
                    output = "Snow is expected, pack snowshoes!";
                }
                else if (Forecast == "rain")
                {
                    output = "Rain is expected, pack rain gear and wear waterproof shoes!";
                }
                else if (Forecast == "thunderstorms")
                {
                    output = "Thunderstorms are expected, seek shelter and avoid hiking on exposed ridges!";
                }
                else if (Forecast == "sunny")
                {
                    output = "It will be sunny today, pack sunblock!";
                }

                return output;
            }
        }

        public string TemperatureMessage
        {
            get
            {
                string output = "";

                if(HighTemp > 75)
                {
                    output = "Its going to be a hot one, pack an extra gallon of water. ";
                }
                if(HighTemp - LowTemp > 20)
                {
                    output += "Temperature swings may happen, wear breathable layers. ";
                }
                if(LowTemp < 20)
                {
                    output += "Temperature may be very low today, be careful and dress warm.";
                }

                return output;
            }
        }
    }
}
