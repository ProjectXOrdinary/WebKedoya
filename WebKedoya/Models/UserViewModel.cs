using System;
using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public partial class UserViewModel
    {
        [Display(Name = "Username")]
        public String UserName { set; get; }

        [Display(Name = "Role")]
        public String RoleName { set; get; }

        [Display(Name = "Email")]
        public String Email { set; get; }

        [Display(Name = "Fullname")]
        public String Fullname { set; get; }
    }
}
