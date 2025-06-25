namespace CoreService.Domain.Entities
{
    public class Rating
    {
        public Rating(Guid id, Guid userId, Guid targetId, string targetType, bool isGoodAnswer, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            TargetId = targetId;
            TargetType = targetType;
            IsGoodAnswer = isGoodAnswer;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid TargetId { get; init; }
        public string TargetType { get; set; } // задумывается что это либо вопрос либо отввет
        public bool IsGoodAnswer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
