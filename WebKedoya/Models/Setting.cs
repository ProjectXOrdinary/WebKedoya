using System.ComponentModel.DataAnnotations;


namespace WebKedoya.Models
{
    public class Setting
    {
        [Key]
        public string SettingID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "name cannot be longer than 50 characters.")]
        [Display(Name ="Nama Setting")]
        public string SettingName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "description cannot be longer than 50 characters.")]
        [Display(Name = "Deskripsi")]
        public string SettingDescription { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "type cannot be longer than 50 characters.")]
        [Display(Name = "Tipe")]
        public string SettingType { get; set; }
    }
}
