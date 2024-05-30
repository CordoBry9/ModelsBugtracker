using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BugTrackerBC.Client.Models
{
    public class ProjectDTO
    {
        private DateTimeOffset _created;
        private DateTimeOffset _startDate;
        private DateTimeOffset? _endDate;

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset Created
        {
            get => _created;
            set => _created = value.ToUniversalTime();
        }
        public DateTimeOffset Start
        {
            get => _startDate;
            set => _startDate = value.ToUniversalTime();
        }

        public DateTimeOffset? End
        {
            get => _endDate;
            set => _endDate = value?.ToUniversalTime();
        }

        public ProjectPriority Priority;

        public bool isArchived { get; set; }

        //relationships
        public int CompanyId { get; set; }
        public virtual CompanyDTO? Company { get; set; }

        public virtual ICollection<UserDTO> Members { get; set; } = new HashSet<UserDTO>();

        public virtual ICollection<TicketDTO> Tickets { get; set; } = new HashSet<TicketDTO>();
    }
}
