using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PostSupplier
    {
        [Required] [MaxLength(50, ErrorMessage = "Max length for Name is 50.")]
        public string Name;
    }

    public class PutSupplier
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length for Name is 50.")]
        public string Name { get; set; }
    }
}