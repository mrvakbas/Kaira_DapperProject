namespace Kaira.WebUI.DTOs.SellingProductDtos
{
    public class UpdateSellingProductDto
    {
        public int SellingProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
