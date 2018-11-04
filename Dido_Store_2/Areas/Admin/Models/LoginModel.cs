using System.ComponentModel.DataAnnotations;

namespace Dido_Store_2.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string UserName { set; get; } 

        [Required(ErrorMessage ="Mời nhập mật khẩu")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}