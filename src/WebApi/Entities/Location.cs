using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public int? LocationId { get; set; }

        [Required, MaxLength(32), Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual Location Parent { get; set; }
    }
}