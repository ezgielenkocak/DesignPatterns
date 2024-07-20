using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DesignPattern.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, RemoveProductCommandHandler removeProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var values = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
             _createProductCommandHandler.Handle(command);
            return Ok("Başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveProduct(RemoveProductCommand command)
        {
            _removeProductCommandHandler.Handle(command);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return Ok("Başarıyla güncellendi");
        }
    }
}
