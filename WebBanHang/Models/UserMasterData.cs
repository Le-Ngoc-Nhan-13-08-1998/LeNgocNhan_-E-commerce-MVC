using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Context
{
    public partial class UserMasterData
    {
        [Display(Name = "Id Người dùng")]
        public int UserId { get; set; }

        [Display(Name = "Họ người dùng")]
        public string FirstName { get; set; }

        [Display(Name = "Tên người dùng")]
        public string LastName { get; set; }

        [Display(Name = "Tài khoản")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Có phải là Admin")]
        public Nullable<bool> IsAdmin { get; set; }

    }
}