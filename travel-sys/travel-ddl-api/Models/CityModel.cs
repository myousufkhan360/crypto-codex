using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class CityModel
    {
        public int CityCode { get; set; }        
        public string CityName { get; set; }
        public int CountryCode { get; set; }
    }
}