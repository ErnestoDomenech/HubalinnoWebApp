using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class Register: AccountBase
    {     
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Username must be at least 5 characters long", MinimumLength = 5)]
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(100, ErrorMessage = "Confirm Password must be at least 8 characters long", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
