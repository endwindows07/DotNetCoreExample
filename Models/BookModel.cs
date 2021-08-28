using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Count { get; set; }
        public int InStock { get; set; }
        public int SaleCount { get; set; }
        public bool IsActive { get; set; }
    }
}
