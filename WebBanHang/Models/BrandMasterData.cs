using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Context
{
    public partial class BrandMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Tên gọi")]
        public string Slug { get; set; }
        [Display(Name = "Hiện ở trang chính")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Hiện mục đặt")]
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày thêm")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> UpdateUtc { get; set; }
        [Display(Name = "Có thể xoá")]
        public Nullable<bool> Deleted { get; set; }
    }
}