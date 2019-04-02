using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Users
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
