using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProject.Models
{
    public class MyExercise
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Exercise Exercise { get; set; }
        public string Username { get; set; }
    }
}
