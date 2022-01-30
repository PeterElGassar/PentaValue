using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class AppUserDto
    {
        public string Id { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string DisplayName { get; set; }

        [Required]
        public string UserName { get; set; }


        //public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }


        public string Token { get; set; }



    }
}
