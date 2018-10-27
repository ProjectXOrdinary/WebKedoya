using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebKedoya.Models
{
    public class KehadiranFormViewModel : IEnumerable<KehadiranFormViewModel>
    {

        private List<KehadiranFormViewModel> ListKehadiran;

        [Display(Name = "ID Kehadiran")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        public int IDKehadiran { set; get; }

        [Display(Name = "Tanggal")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        //[DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
            ApplyFormatInEditMode = true)]
        public DateTime Tanggal { set; get; }

        [Display(Name = "Kode Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String KodeJenisIbadah { set; get; }

        [Display(Name = "Jenis Ibadah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String NamaJenisIbadah { set; get; }

        [Display(Name = "Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String KodeJenisJemaat { set; get; }

        [Display(Name = "Jenis Jemaat")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [StringLength(256, ErrorMessage = "{0} tidak boleh lebih {1} karakter.")]
        public String NamaJenisJemaat { set; get; }

        [Display(Name = "Jumlah")]
        [Required(ErrorMessage = "{0} harus diisi.")]
        [Range(0, 1000)]
        public Double Jumlah { set; get; }

        public IEnumerator<KehadiranFormViewModel> GetEnumerator()
        {
            return ListKehadiran.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ListKehadiran.GetEnumerator();
        }
    }
}
