using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProject.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ExplanationURL { get; set; }
        public byte[]? image { get; set; }
    }
}
