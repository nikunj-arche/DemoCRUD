using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Models
{
    public class EditStateModel
    {

        public List<SelectListItem> CountryName { get; set; }
        public int StateId { get; set; }
        public string StatName { get; set; }
    }
}