using System.ComponentModel.DataAnnotations;

namespace Practica.EF.MVC.Models
{
    public class CategoriesView
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The category name is a required field!")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Category name should be min 3 and max 15 length")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Category description should be max 300 length")]
        public string Description { get; set; }

    }
}