// UserAccount.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWMS.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public required string Email { get; set; }

        [Required, MaxLength(255)]
        public required string PasswordHash { get; set; }

        [Required, MaxLength(100)]
        public required string UserName { get; set; }

        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
