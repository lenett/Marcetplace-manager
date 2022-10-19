namespace MM.Areas.Goods.Models
{
    public class Pictures
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public int ProductId { get; set; }
    }
}
