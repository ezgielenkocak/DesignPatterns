using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Queries
{

    //mvc kullanırsam güncellenecek ürünün bilgilerini direkt getirebilmek için buraya ihtiyaç duydum ama api kullandığım için şuanlık deaktive
    public class GetProductUpdateByIdQuery:IRequest<UpdateProductByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductUpdateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
