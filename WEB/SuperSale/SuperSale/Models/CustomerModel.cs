using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperSale.Models
{
    public partial class CustomerModel
    {
        public long CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
