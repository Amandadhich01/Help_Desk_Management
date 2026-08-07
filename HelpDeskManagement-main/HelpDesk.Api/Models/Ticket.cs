using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Api.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Priority { get; set; } = "Low";

        [Required]
        public string Status { get; set; } = "Open";

        [Required]
        [StringLength(100)]
        public string RaisedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}