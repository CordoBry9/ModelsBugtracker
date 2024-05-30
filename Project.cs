using BugTrackerBC.Client.Models;
using BugTrackerBC.Data;
using BugTrackerBC.Helpers.Extensions;
using Microsoft.AspNetCore.Connections;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerBC.Models
{
    public class Project
    {

        private DateTimeOffset _created;
        private DateTimeOffset _startDate;
        private DateTimeOffset? _endDate;

        public int Id {  get; set; }

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

        public bool Archived { get; set; }

        //relationships
        [Required]
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; } = new HashSet<ApplicationUser>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }

    public static class ProjectExtensions
    {
        public static ProjectDTO ToDTO (this Project project)
        {
            ProjectDTO dto = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Created = project.Created,
                Start = project.Start,
                End = project.End,
                Priority = project.Priority,
                CompanyId = project.CompanyId,
                isArchived = project.Archived,
                
            };

            if (project.Company is not null)
            {
                project.Company.Projects.Clear();

                CompanyDTO companyDTO = project.Company.ToDTO();
                dto.Company = companyDTO;
            }

            foreach(ApplicationUser member in project.Members)
            {
                UserDTO memberDTO = member.ToDTO();
                dto.Members.Add(memberDTO);
            }

            foreach(Ticket ticket in project.Tickets)
            {
                TicketDTO ticketDTO = ticket.ToDTO();
                dto.Tickets.Add(ticketDTO);
            }

            return dto;
        }
    }
}
