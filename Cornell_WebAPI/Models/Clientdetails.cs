namespace Cornell_WebAPI.Models
{
    public class Clientdetails
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string NIN_No { get; set; }

        public string? Address { get; set; }

        public int TelephoneNo { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateRegistered { get; set; }

        public byte[] ProfilePic { get; set; }

        public string? Description { get; set; }
    }
}
