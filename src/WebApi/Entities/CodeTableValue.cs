using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class CodeTableValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CodeTableId { get; set; }

        [Required, MaxLength(100), Index(IsUnique = true)]
        public string Value { get; set; }

        public virtual CodeTable CodeTable { get; set; }
    }
}