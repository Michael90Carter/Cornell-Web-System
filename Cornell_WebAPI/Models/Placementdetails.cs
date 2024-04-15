namespace Cornell_WebAPI.Models
{
    public class Placementdetails
    {

        public int Id { get; set; }

        public Clientdetails? Clientdetails { get; set; }

        public Jobdetails? Joboffer { get; set; } 

    }
}
