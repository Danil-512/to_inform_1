namespace CoreService.Domain.Entities
{
    public class Answer
    {
        public Answer(Guid id, Guid questionId, Guid userId, string content, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            QuestionId = questionId;
            UserId = userId;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public Guid QuestionId { get; init; }
        public Guid UserId { get; init; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
