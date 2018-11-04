namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
            Ratings = new HashSet<Rating>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(128)]
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        [DisplayName("Tên")]

        public string Name { get; set; }

        [StringLength(128)]
        public string Alias { get; set; }

        [DisplayName("Hãng")]
        public int? BranchID { get; set; }

        [DisplayName("Ảnh")]
        public string Image { get; set; }

        [DisplayName("Ảnh chi tiết")]
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Bạn chưa nhập giá")]
        public decimal? Price { get; set; }

        [DisplayName("Khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int? Quantity { get; set; }

        [StringLength(128)]
        public string Createdby { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [DisplayName("Bảo hành (tháng)")]
        public int? Warranty { get; set; }

        [DisplayName("Nội dung")]
        public string Content { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        public string Description { get; set; }

        [DisplayName("Tình trạng")]
        public bool? Status { get; set; }


        public int? ViewCount { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
