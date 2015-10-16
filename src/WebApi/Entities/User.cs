using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public partial class User : IUser<int>
    {
        [Key]
        public int Id { get; set; }

        public int? LocationId { get; set; }
        
        [Required, MaxLength(32), Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public Location Location { get; set; }
    }
}