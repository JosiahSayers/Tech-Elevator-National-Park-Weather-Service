using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SettingsViewModel
    {
        public string TemperatureSetting { get; set; }
        public List<SelectListItem> Choices
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem("Fahrenheit", "fahrenheit"),
                    new SelectListItem("Celsius", "celsius")
                };
            }
        }
    }
}
