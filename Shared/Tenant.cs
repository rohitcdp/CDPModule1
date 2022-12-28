namespace CDPModule1.Shared
{


    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string? Telephone { get; set; }
        public string? Fax { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? BankingDetails { get; set; }
        public string? GstNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? Website { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
