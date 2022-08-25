using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Context
{
    public partial class CategoryMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Tên gọi")]
        public string Slug { get; set; }
        [Display(Name = "Hiện ở trang chính")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Hiển thị")]
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Xoá")]
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày thêm")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }

    }
}