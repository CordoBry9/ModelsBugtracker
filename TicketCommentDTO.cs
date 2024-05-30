using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BugTrackerBC.Client.Models
{
    public class TicketCommentDTO
    {
        private DateTimeOffset _created;
        public int Id { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTimeOffset Created
        {
            get => _created;
            set => _created = value.ToUniversalTime();
        }

        // Relationships
        public int TicketId { get; set; }
        public virtual TicketDTO? Ticket { get; set; }

        public string? UserId { get; set; }
        public virtual UserDTO? User { get; set; }
    }
}
