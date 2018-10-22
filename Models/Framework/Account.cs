namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        public string Username { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        public int? RoleID { get; set; }

        public int? UserID { get; set; }

        public bool? Status { get; set; }
    }
}
