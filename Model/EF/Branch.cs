﻿namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            Products = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(128)]
        public string Alias { get; set; }

        [StringLength(128)]
        [DisplayName("Tên hãng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên hãng")]
        public string BranchName { get; set; }

        [StringLength(512)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }

        [StringLength(128)]
        public string Createdby { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [DisplayName("Ảnh")]
        public string Image { get; set; }

        [DisplayName("Tình trạng")]
        public bool? Status { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? DisplayOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}