using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LLArtExhibition_2.ViewModels
{
    public class ArtViewModel : IdentityUser
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "CoverUrl")]
        [RegularExpression(@"^(https?|ftp)://[^\s/$.?#].[^\s]*$", ErrorMessage = "请输入有效的 URL")]
        public string CoverUrl { get; set; }
    }
}
