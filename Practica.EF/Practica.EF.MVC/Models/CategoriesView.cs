using System.ComponentModel.DataAnnotations;

namespace Practica.EF.MVC.Models
{
    public class CategoriesView
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [StringLength(300, MinimumLength = 1)]
        public string Description { get; set; }

    }
}