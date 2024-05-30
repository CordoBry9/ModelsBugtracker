using System.ComponentModel.DataAnnotations;

namespace BugTrackerBC.Client.Models
{
    public class InviteDTO
    {
            private DateTimeOffset _invited;
            private DateTimeOffset? _joined;

            public int Id { get; set; }

            [Required]
            public DateTimeOffset InviteDate
            {
                get => _invited;
                set => _invited = value.ToUniversalTime();
            }
            public DateTimeOffset? JoinDate
            {
                get => _joined;
                set => _joined = value?.ToUniversalTime();
            }

            public Guid CompanyToken { get; set; }

            [Required]

            public string? InviteeEmail { get; set; }

            public string? InviteeFirstName { get; set; }
            public string? InviteeLastName { get; set; }

            public string? Message { get; set; }

            public bool IsValid { get; set; } //to check if invite is valid 

            // Relationships
            public int CompanyId { get; set; }
            public virtual CompanyDTO? Company { get; set; }

            public int ProjectId { get; set; }
            public virtual ProjectDTO? Project { get; set; }
            public string? InvitorId { get; set; }
            public virtual UserDTO? Invitor { get; set; }
            public string? InviteeId { get; set; }
            public virtual UserDTO Invitee { get; set; } = new UserDTO();

    }
}
