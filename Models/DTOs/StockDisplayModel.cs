namespace DMobileSite.Models.DTOs
{
    public class StockDisplayModel
    {
        public int Id { get; set; }
        public int MobileId { get; set; }
        public int Quantity { get; set; }
        public string? MobileName { get; set; }
    }
}
