namespace DesignPattern.Mediator.MediatorPattern.Results
{
    public class UpdateProductByIdQueryResult
    {
        //mvc kullanırsam güncellenecek ürünün bilgilerini direkt getirebilmek için buraya ihtiyaç duydum ama api kullandığım için şuanlık deaktive
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public string ProductStockType { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}
