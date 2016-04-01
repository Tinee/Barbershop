namespace BarberShop.Models
{
    public class UpdatePasswordModel
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}