namespace CoreService.Domain.Entities
{
    public class Company
    {
        public Company(
                        Guid id,
                        string name,
                        int taxID,
                        string address,
                        DateTime foundationDate,
                        int employeeCount,
                        int industry,
                        string phoneNumber,
                        DateTime createdAt,
                        DateTime updatedAt)
        {
            Id = id;
            Name = name;
            TaxID = taxID;
            Address = address;
            FoundationDate = foundationDate;
            EmployeeCount = employeeCount;
            Industry = industry;
            PhoneNumber = phoneNumber;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; init; } 
        public string Name { get; set; }
        public int TaxID { get; set; } // ИНН
        public string Address { get; set; }
        public DateTime FoundationDate { get; set; }
        public int EmployeeCount { get; set; }

        /// <summary>
        /// вопрос про enum
        /// </summary>
        public int Industry { get; set; } // enum
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
