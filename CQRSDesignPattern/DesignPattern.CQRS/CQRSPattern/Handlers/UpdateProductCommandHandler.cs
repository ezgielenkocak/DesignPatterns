using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateProductCommand command)
        {
            _context.Products.Update(new Product
            {
                Description = command.Description,
                Status = command.Status,    
                Name = command.Name,    
                 Price = command.Price,
                 Stock = command.Stock,
                 ProductID =command.ProductID
            }); 
            _context.SaveChanges(); 
        }
    }
}
