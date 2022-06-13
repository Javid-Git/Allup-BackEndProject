﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
    }
}
