using System.Text.Json.Serialization;

namespace Cornell_WebAPI.Models
{
    public class Countriesdetails
    {
        public int Id { get; set; }

       
        public string? Flag { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName{ get; set; }

        public string? Status { get; set; }


    }
}
