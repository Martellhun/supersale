using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public class CustomerDetailsModel
    {

        public CustomerDetailsModel(CustomerModel customer, IEnumerable<Car> cars)
        {
            this.CustomerId = customer.CustomerId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.Company = customer.Company;
            this.Email = customer.Email;
            this.CustomerCars = cars;
        }

        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public IEnumerable<Car> CustomerCars { get; set; }
    }
}
