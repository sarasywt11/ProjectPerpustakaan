using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpusWebProject.Models
{
    public class Peminjaman
    {
        [Key]
        public int IdPeminjaman { get; set; }

        [ForeignKey("Buku")]
        public int IdBuku { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        public DateTime TanggalPinjam { get; set; }

        public DateTime? TanggalKembali { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;


        public Buku? Buku { get; set; }

        public User? User { get; set; }
    }
}