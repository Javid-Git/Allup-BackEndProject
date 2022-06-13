using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}
