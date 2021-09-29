using crudcqrs.application.features.queries;
using CrudCqrs.Domain.Models;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.QueriesHandle
{
    public class GetproductbyIdqueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationContext _context;
        public GetproductbyIdqueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {

            var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }
}
