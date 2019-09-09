using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
        [Display(Name = "Regular Pick Up Day")]
        public string PickUpDay { get; set; }
        [Display(Name = "Special Pick Up Date")]
        public string SpecialPickUpDate { get; set; }
        [Display(Name = "Temporary Service Suspension Start Date")]
        public string TempSuspendStart { get; set; }
        [Display(Name = "Temporary Service Suspension End Date")]
        public string TempSuspendEnd { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [ForeignKey ("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Latitude { get; set; }
        [NotMapped]
        public double Longitude { get; set; }
    }
}