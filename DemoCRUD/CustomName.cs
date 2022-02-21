using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DemoCRUD
{
    public class CustomName:ValidationAttribute
    {
        WorldEntities db = new WorldEntities();
        private readonly string _char;

        public object[] CountryName { get; private set; }

        public CustomName(string chars) : base("{ 0} contains Invalid" )
        {
            _char = chars;
        }
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var std = db.Country.Find(CountryName);
            if (value != null)
            {
                string msg = value.ToString();
                //if (msg = std)
                //{
                //    return ValidationResult.Success;
                //}
            }
            return new ValidationResult("This Name Already Exist!");
        }
    }
}