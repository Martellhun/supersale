using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperSale.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
