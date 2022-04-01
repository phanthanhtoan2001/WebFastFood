namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTDDHs = new HashSet<CTDDH>();
            CTPNs = new HashSet<CTPN>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(25)]
        public string Tensp { get; set; }

        public int? Dongia { get; set; }

        [StringLength(200)]
        public string Size { get; set; }

        [StringLength(30)]
        public string Hinhanh { get; set; }

        public int? Soluongton { get; set; }

        [StringLength(6)]
        public string MaNCC { get; set; }

        public int? MaLoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public virtual NCC NCC { get; set; }
    }
}
