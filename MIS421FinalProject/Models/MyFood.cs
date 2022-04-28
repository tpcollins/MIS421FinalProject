using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProject.Models
{
    public class MyFood
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public Food Food { get; set; }
        public string Username { get; set; }
    }
}
