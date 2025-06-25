using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Domain.Entities
{
    public class UserProfile
    {
        public UserProfile(Guid id,
                           Guid userId,
                           string fIO,
                           string bio,
                           string githubUrl,
                           string linkedInUrl,
                           string resumeUrl,
                           Guid companyId,
                           int position,
                           Guid telegramId,
                           int experienceYears)
        {
            Id = id;
            UserId = userId;
            FIO = fIO;
            Bio = bio;
            GithubUrl = githubUrl;
            LinkedInUrl = linkedInUrl;
            ResumeUrl = resumeUrl;
            CompanyId = companyId;
            Position = position;
            TelegramId = telegramId;
            ExperienceYears = experienceYears;
        }

        public Guid Id { get; init; }
        public Guid UserId { get; set; }
        public string FIO { get; set; }
        public string Bio { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string ResumeUrl { get; set; }
        public Guid CompanyId { get; set; }
        public int Position { get; set; } // enum
        public Guid TelegramId { get; set; }
        public int ExperienceYears { get; set; }
    }
}
