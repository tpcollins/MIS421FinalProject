using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProject.Models
{
    public class MyExercise
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise? Exercise { get; set; }
        public string Username { get; set; }
    }
}
