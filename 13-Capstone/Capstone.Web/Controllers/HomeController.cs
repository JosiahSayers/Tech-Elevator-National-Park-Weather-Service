using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkSqlDAL parkDAL;
        private readonly ISurvey_ResultSqlDAL survey_ResultDAL;
        private readonly IWeatherSqlDAL weatherDAL;

        public HomeController(IParkSqlDAL parkDAL, ISurvey_ResultSqlDAL survey_ResultDAL, IWeatherSqlDAL weatherDAL)
        {
            this.parkDAL = parkDAL;
            this.survey_ResultDAL = survey_ResultDAL;
            this.weatherDAL = weatherDAL;
        }


        public IActionResult Index()
        {
            List<Park> parks = parkDAL.GetAllParks();

            return View(parks);
        }

        public IActionResult Details(string data)
        {
            DetailsViewModel model = new DetailsViewModel();
            model.Park = parkDAL.GetPark(data);
            model.FiveDayWeather = weatherDAL.GetWeatherForPark(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Survey()
        {
            List<Park> parks = parkDAL.GetAllParks();
            ViewBag.ParkSelectList = parkDAL.GetParkSelectList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Survey(Survey_Result surveyResult)
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
