namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            CTDDHs = new HashSet<CTDDH>();
        }

        [Key]
        public int MaDDH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaydat { get; set; }

        public bool? Tinhtrangdonhang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaygiao { get; set; }

        public int? MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDHs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
