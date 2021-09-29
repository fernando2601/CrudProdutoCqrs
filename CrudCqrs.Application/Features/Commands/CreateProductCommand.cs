using CrudCqrs.Domain.Models;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
        
    }
}
