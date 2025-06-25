namespace CoreService.Domain.Entities
{
    public class User
    {
        public User(
            Guid id,
            string userName,
            string email,
            bool emailConfirmed,
            string passwordHash,
            int phoneNumber,
            bool isExpert,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            UserName = userName;
            Email = email;
            EmailConfirmed = emailConfirmed;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            IsExpert = isExpert;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public int PhoneNumber { get; set; }
        public bool IsExpert { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
