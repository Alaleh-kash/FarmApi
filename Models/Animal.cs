namespace FarmApi.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public int? FarmerId { get; set; }   // allow null in SQL
        public string? Name { get; set; }    // allow null
        public string? Type { get; set; }    // allow null
        public int? Age { get; set; }        // allow null
        public DateTime? CreatedAt { get; set; } // allow null
    }
}
