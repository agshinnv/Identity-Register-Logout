namespace FrontToBack.Models
{
    public class Slider : BaseEntity
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
        public string Image { get; set; }
    }
}
