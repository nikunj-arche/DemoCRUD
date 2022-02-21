using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoCRUD.Models
{
    public class EditModel
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Enter Country Name")]
        public string CountryName { get; set; }
    }
}