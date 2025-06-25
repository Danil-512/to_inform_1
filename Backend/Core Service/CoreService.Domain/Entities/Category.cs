namespace CoreService.Domain.Entities
{
    public class Category
    {
        public Category(Guid id, string name, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
