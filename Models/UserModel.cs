using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public UserStatus UserType { get; set; }

        public string Nationality { get; set; }
    }
}
