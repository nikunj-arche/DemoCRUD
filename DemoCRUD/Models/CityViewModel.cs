using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCRUD.Models
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public int stateId { get; set; }
        public string statename { get; set; }
        public int countryId { get; set; }
        public string countryname { get; set; }
    }
}