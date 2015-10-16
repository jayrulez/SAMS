using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class CodeTable
    {
        public CodeTable()
        {
            Values = new Collection<CodeTableValue>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(32), Index(IsUnique = true)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CodeTableValue> Values { get; set; }
    }
}