using CrudCqrs.Application.Features.Commands;
using CrudCqrs.Domain.Models;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.CommandHandler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly ApplicationContext _context;
        public CreateProductCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.BuyingPrice = command.BuyingPrice;
            product.Rate = command.Rate;
            product.Description = command.Description;
            _context.Products.Add(product);
            await _context.SaveChanges();
            return true;
        }
    }
}