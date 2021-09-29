using CrudCqrs.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrudCqrs.Application.Features.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
