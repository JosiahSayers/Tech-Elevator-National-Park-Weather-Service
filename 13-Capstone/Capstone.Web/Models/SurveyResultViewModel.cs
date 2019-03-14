using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultViewModel
    {
        public List<Park> Parks { get; set; }
        public List<KeyValuePair<string, int>> GetTopRankedParks { get; set; }
    }
}
