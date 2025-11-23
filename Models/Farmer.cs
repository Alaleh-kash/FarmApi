namespace FarmApi.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string? Name { get; set; }       // allow null
        public string? Location { get; set; }   // allow null
        public DateTime? CreatedAt { get; set; } // allow null
    }
}
