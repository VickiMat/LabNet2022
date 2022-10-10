using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica.EF.WebAPI.Models
{
    public class CategoriesRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}