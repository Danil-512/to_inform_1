using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Domain.Entities
{
    public class Comment
    {
        public Comment(Guid id, string content, Guid userId, Guid targetId, string targetType, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Content = content;
            UserId = userId;
            TargetId = targetId;
            TargetType = targetType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; }
        public string Content { get; set; }
        public Guid UserId { get; init; }
        public Guid TargetId { get; init; } // задумывается что это либо вопрос либо отввет
        public string TargetType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
