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
       
        public Nullable<int> TypeId { get; set; }
        
        public string Slug { get; set; }
       
        public Nullable<int> BrandId { get; set; }
       
        public Nullable<bool> Deleted { get; set; }
       
        public Nullable<bool> ShowHomePage { get; set; }
       
        public Nullable<int> DisplayOrder { get; set; }
       
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }


    }
}