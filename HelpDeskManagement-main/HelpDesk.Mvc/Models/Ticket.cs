using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Mvc.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [Required]
        [StringLength(500)]
        public required string Description { get; set; }

        [Required]
        public required string Priority { get; set; }

        [Required]
        public required string Status { get; set; }

        [Required]
        [StringLength(100)]
        public required string RaisedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}