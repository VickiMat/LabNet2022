using System;

namespace Practica.EF.Entities.DTO
{
    public class CustomersOrdersDto
    {
        public string CustomerID { get; set; }

        public string Region { get; set; }

        public string CompanyName { get; set; }

        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int NumberOfOrders { get; set; }
    }
}
