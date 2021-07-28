using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO.Products
{
    public class ProductsInRangeDTO
    {
        [Required]
        public int From { get; set; }

        [Required]
        [Range(1, 100_000)]
        public int To { get; set; }
    }
}
