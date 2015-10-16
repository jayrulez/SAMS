using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Entities
{
    public class AssetAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AssetId { get; set; }

        public int? LocationId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        public DateTime? UnassignedDate { get; set; }

        [Required]
        public int AssignedByUserId { get; set; }
        
        public int? UnassignedByUserId { get; set; }

        public AssetAssignmentStatus Status { get; set; }

        public string Description { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
        public virtual User AssignedByUser { get; set; }
        public virtual User UnassignedByUser { get; set; }
    }
}