using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        [Display(Name = "Nama User")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Fullname cannot be longer than 50 characters.")]
        [Display(Name = "Nama Lengkap")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "RoleID cannot be longer than 50 characters.")]
        [Display(Name = "Role")]
        public string RoleID { get; set; }
    }
}
