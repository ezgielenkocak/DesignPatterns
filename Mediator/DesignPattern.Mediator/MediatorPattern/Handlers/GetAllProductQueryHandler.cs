﻿using DesignPattern.Mediator.Dal;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryResult>>
    {
        private readonly Context _context;

        public GetAllProductQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(x => new GetAllProductQueryResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,    
                ProductStock=x.ProductStock,    
                ProductCategory = x.ProductCategory,    
                ProductStockType = x.ProductStockType,  
                ProductPrice = x.ProductPrice,  
            }).AsNoTracking().ToListAsync();
        }
    }
}
