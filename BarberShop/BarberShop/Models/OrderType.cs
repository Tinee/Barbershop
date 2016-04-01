namespace BarberShop.Models
{
    public class OrderType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredTime { get; set; }
        public decimal Price { get; set; } 
    }
}