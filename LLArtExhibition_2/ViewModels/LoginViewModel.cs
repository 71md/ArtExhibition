using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LLArtExhibition_2.ViewModels
{
    public class LoginViewModel:IdentityUser
    {

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

    }
}
