using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProject.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Calories { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbs { get; set; }

    }
}
