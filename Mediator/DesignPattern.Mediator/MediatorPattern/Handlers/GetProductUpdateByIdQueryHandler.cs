using DesignPattern.Mediator.Dal;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
 
    //mvc kullanırsam güncellenecek ürünün bilgilerini direkt getirebilmek için buraya ihtiyaç duydum ama api kullandığım için şuanlık deaktive
    public class GetProductUpdateByIdQueryHandler : IRequestHandler<GetProductUpdateByIdQuery, UpdateProductByIdQueryResult>
    {
        private readonly Context _context;

        public GetProductUpdateByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<UpdateProductByIdQueryResult> Handle(GetProductUpdateByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            return new UpdateProductByIdQueryResult
            {
                ProductCategory=values.ProductCategory,
                ProductStock=values.ProductStock,   
                ProductId=values.ProductId,
                ProductName=values.ProductName, 
                ProductPrice=values.ProductPrice,
                ProductStockType=values.ProductStockType,
            };
        }
    }
}
