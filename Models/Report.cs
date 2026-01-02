// Report.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SWMS.Models
{
    public class Report
    {
        [Key]
            public int ReportId { get; set; }

            [Required, MaxLength(100)]
            public required string WasteType { get; set; }

            [MaxLength(500)]
            public string? Description { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Required]
        public int UserAccountId { get; set; }

        public UserAccount? UserAccount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
