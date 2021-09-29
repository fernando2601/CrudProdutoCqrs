using CrudCqrs.Domain.Models;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace crudcqrs.application.features.queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        
    }
}
