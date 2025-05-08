using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.Category
{
    public class CategoryPost
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
