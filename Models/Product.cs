﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public double DicountedPrice { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double ExTax { get; set; }
        [StringLength(maximumLength:4)]
        public string Seria { get; set; }
        [Range(0,9999)]
        public int Code { get; set; }
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        [StringLength(maximumLength:1000)]
        public string Description { get; set; }
        [StringLength(maximumLength: 255)]
        public string MainImnage { get; set; }
        [StringLength(maximumLength: 255)]
        public string HoverImage { get; set; }
        public string DetailImages { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsNewArrivel { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsFeature { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public Brand Brand { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        [NotMapped]
        public IEnumerable<IFormFile> DetailFormImages { get; set; }
        [NotMapped]
        public IFormFile MainFormImage { get; set; }
        [NotMapped]
        public IFormFile HoverFormImage { get; set; }

    }
}
