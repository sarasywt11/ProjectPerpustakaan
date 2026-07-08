using System.ComponentModel.DataAnnotations;

namespace PerpusWebProject.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; } = string.Empty;

        [StringLength(200)]
        public string Alamat { get; set; } = string.Empty;

        [StringLength(20)]
        public string NomorTelepon { get; set; } = string.Empty;

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}