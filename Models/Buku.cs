using System.ComponentModel.DataAnnotations;

namespace PerpusWebProject.Models
{
    public class Buku
    {
        [Key]
        public int IdBuku { get; set; }

        [Required]
        [StringLength(150)]
        public string Judul { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Penulis { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Penerbit { get; set; } = string.Empty;

        public int TahunTerbit { get; set; }

        [Required]
        [StringLength(50)]
        public string Kategori { get; set; } = string.Empty;

        public int Stok { get; set; }
    }
}