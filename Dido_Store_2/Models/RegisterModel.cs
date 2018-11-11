using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dido_Store_2.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Yêu cầu nhập Ngày sinh")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
    }
}