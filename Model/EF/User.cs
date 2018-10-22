namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(128)]
        [DisplayName("Họ và tên")]
        [Required(ErrorMessage ="Bạn chưa nhập họ tên")]
        public string Name { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(16)]
        [DisplayName("SĐT")]
        [Required(ErrorMessage ="Bạn chưa nhập SĐT")]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? BirthDay { get; set; }

        [StringLength(16)]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [StringLength(128)]
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn chưa nhập tên đăng nhập")]
        public string Username { get; set; }

        [StringLength(128)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage ="Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }

        [DisplayName("Chức vụ")]
        public int? RoleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual Role Role { get; set; }
    }
}
