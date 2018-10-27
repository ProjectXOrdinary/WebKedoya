using System;
using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public class JenisJemaat
    {
        [Display(Name = "ID Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        public int IDJenisJemaat { set; get; }

        [Display(Name = "Kode Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        public String KodeJenisJemaat { set; get; }

        [Display(Name = "Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String NamaJenisJemaat { set; get; }

        [Display(Name = "Keterangan Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String KeteranganJenisJemaat { set; get; }
    }
}
