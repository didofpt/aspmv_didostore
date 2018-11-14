namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(50)]
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string ShipName { get; set; }

        [StringLength(10)]
        [MinLength(10, ErrorMessage = "Vui lòng nhập SĐT đúng")]
        [Phone(ErrorMessage = "Vui lòng nhập SĐT đúng")]
        [DisplayName("SĐT")]
        [Required(ErrorMessage = "Vui lòng nhập SĐT")]
        public string ShipMobile { get; set; }

        [StringLength(150)]
        [MinLength(10, ErrorMessage = "Địa chỉ quá ngắn")]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string ShipEmail { get; set; }

        public decimal? Total { get; set; }

        [StringLength(200)]
        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        [StringLength(256)]
        public string PaymentMethod { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? PaymentStatus { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }
    }
}
