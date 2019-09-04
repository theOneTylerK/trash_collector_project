using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
        [Display(Name = "Pick Up Day")]
        public int PickUpDayId { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

    }
}