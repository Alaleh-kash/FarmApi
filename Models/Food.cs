namespace FarmApi.Models
{
    public class Food
    {
        public int Id { get; set; }
        public int? AnimalId { get; set; }      // allow null
        public string? FoodName { get; set; }   // allow null
        public int? QuantityPerDay { get; set; } // allow null
    }
}
