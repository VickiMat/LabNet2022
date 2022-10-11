namespace Practica.EF.WebAPI.Models
{
    public class SuppliersRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}