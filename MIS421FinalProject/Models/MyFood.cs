using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProject.Models
{
    public class MyFood
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }

        [Required]
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public Food? Food { get; set; }
        public string Username { get; set; }
    }
}
