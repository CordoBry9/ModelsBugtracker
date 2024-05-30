﻿namespace BugTrackerBC.Client.Models
{
    public class UserDTO
    {
        public string? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName => $"{FirstName} {LastName}";

        public string? ImageUrl { get; set; }

        public string? Email { get; set; }

    }
}
