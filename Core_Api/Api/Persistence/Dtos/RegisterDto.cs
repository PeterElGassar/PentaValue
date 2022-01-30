using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Persistence.Dtos
{
    public class RegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        public string DisplayName { get; set; } 

        [Required]
        public string Role { get; set; }


        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$"
            ,ErrorMessage = "Password must have 1 Uppercase,1 lowercase 1 special character and the length should be between 6-10 characters")]
        [Required]
        public string Password { get; set; }

        public string ConfirmPassword{ get; set; }

        public string Token { get; set; }



    }
}
