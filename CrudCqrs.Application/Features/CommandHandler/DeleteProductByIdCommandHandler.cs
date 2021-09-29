using CrudCqrs.Application.Features.Commands;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.CommandHandler
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly ApplicationContext _context;
        public DeleteProductByIdCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (product == null) return default;
            _context.Products.Remove(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
