namespace Terminator.Core.Models
{
    using Terminator.Core.Models.Base;

    public class User : GuidEntityBase
    {
        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }

        public string? Email { get; set; }

        public string? LinkedInAuthToken { get; set; }

        public bool LinkToLinkedIn { get; set; }

        public User() : base()
        {
        }

        public User(Guid id) : base(id)
        {
        }

        public User(string email, string passwordHash, string passwordSalt, string linkedInAuthToken, bool linkToLinkedIn) : this()
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Email = email;
            LinkedInAuthToken = linkedInAuthToken;
            LinkToLinkedIn = linkToLinkedIn;
        }

        public User(Guid id, string email, string passwordHash, string passwordSalt, string linkedInAuthToken, bool linkToLinkedIn) : this(id)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Email = email;
            LinkedInAuthToken = linkedInAuthToken;
            LinkToLinkedIn = linkToLinkedIn;
        }
    }
}
