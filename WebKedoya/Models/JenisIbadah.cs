using System;
using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public class JenisIbadah
    {

        [Display(Name = "ID Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        public int IDJenisIbadah { set; get; }

        [Display(Name = "Kode Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        public String KodeJenisIbadah{ set; get; }

        [Display(Name = "Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String NamaJenisIbadah { set; get; }

        [Display(Name = "Keterangan Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String KeteranganJenisIbadah{ set; get; }
    }
}
