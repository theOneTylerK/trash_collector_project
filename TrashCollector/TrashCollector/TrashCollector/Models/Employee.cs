using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
   
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [ForeignKey ("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}