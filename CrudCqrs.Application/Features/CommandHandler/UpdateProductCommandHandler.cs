using crudcqrs.application.features.commands;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.CommandHandler
{
    public class UpdateProductCommandHandler : IRequestHandler<Updateproductcommand, int>
    {
        private readonly ApplicationContext _context;
        public UpdateProductCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(Updateproductcommand command, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == command.id).FirstOrDefault();
            if (product == null)
            {
                return default;
            }
            else
            {
                product.Barcode = command.barcode;
                product.Name = command.name;
                product.BuyingPrice = command.buyingprice;
                product.Rate = command.rate;
                product.Description = command.description;
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}