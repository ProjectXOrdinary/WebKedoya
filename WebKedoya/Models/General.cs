using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public class General
    {
        [Key]
        public string GeneralID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "name cannot be longer than 50 characters.")]
        [Display(Name = "Name Variabel")]
        public string GeneralName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "description cannot be longer than 50 characters.")]
        [Display(Name = "Deskripsi")]
        public string GeneralDescription { get; set; }
 
    }
}
