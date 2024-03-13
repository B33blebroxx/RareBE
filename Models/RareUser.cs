namespace RareBE.Models
{
    public class RareUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public string? Uid { get; set; }
    }
}
