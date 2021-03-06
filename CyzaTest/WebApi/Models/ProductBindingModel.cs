﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PostProduct
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for Name is 50.")]
        public string Name { get; set; }
    }

    public class PutProduct
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length for Name is 50.")]
        public string Name { get; set; }
    }
}