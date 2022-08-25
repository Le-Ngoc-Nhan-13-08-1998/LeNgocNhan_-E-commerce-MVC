using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Context
{
    public partial class ProductMasterData
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên sản phẩm")]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Chưa chọn ảnh")]
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Chưa chọn danh mục")]
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "ID phân loại")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tải đầy đủ")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Chưa chọn giá")]
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Required(ErrorMessage = "Chưa chọn giá đền xuất")]
        [Display(Name = "Giá đề xuất")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Số Id")]
        public Nullable<int> TypeId { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên gọi")]
        [Display(Name = "Tên gọi")]
        public string Slug { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Có thể xoá")]
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiển thị")]
        public Nullable<bool> ShowHomePage { get; set; }
        [Display(Name = "HIện đặt")]
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày thêm")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }


    }
}