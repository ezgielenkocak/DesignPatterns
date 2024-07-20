namespace DesignPattern.CQRS.CQRSPattern.Queries
{
    public class GetProductByIdQuery
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
