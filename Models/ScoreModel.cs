using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceGameBackend.Models
{
    [Table("Scores")]
    public class ScoreModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        public int Level { get; set; }
        public int Scores { get; set; }
        public DateTime? Created { get; set; } = DateTime.UtcNow;
    }
}
