using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBookApp.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 5)]
        public string StreetAddress { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Country { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
