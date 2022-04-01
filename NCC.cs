namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NCC")]
    public partial class NCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NCC()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(6)]
        public string MaNCC { get; set; }

        [StringLength(25)]
        public string TenNCC { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
