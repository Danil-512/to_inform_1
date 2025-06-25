namespace CoreService.Domain.Entities
{
    public class Question
    {
        public Question(Guid id,
                        Guid userId,
                        string title,
                        string content,
                        Guid categoryId,
                        bool isUrgent,
                        int viewsCount,
                        DateTime createdAt,
                        DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Content = content;
            CategoryId = categoryId;
            IsUrgent = isUrgent;
            ViewsCount = viewsCount;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; init; }
        public bool IsUrgent { get; set; }
        public int ViewsCount { get; set; }

        // public bool VotesCount { get; set; } // ?
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
