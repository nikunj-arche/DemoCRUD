using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Models
{
    public class AddCityModel
    {
        public List<SelectListItem> CountryName { get; set; }
        public List<SelectListItem> StateName { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
    }
}