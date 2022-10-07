using System.ComponentModel.DataAnnotations;

namespace Practica.EF.MVC.Models
{
    public class SuppliersView
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The company name is a required field")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 40 length")]
        public string CompanyName { get; set; }

        [MaxLength(30, ErrorMessage = "The contact name can´t have more than 30 lenght")]
        public string ContactName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The city is a required field")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First Name Should be min 3 and max 15 length")]
        public string City { get; set; }

        [MaxLength(15, ErrorMessage = "The country can´t have more than 15 lenght")]
        public string Country { get; set; }
    }
}