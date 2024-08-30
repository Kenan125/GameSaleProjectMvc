using System.ComponentModel.DataAnnotations;

namespace GameSaleProject_Entity.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public string? CurrentPassword { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string? ConfirmNewPassword { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }
}
