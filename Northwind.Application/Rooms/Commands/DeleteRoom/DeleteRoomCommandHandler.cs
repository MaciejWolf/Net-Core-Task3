using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly NorthwindDbContext context;

        public DeleteRoomCommandHandler(NorthwindDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Rooms
                .FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            context.Rooms.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
