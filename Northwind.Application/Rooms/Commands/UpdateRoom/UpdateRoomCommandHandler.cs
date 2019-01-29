using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly NorthwindDbContext context;

        public UpdateRoomCommandHandler(NorthwindDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Rooms
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.Name = request.Name;
            entity.Floor = request.Floor;
            entity.Seats = request.Seats;

            context.Rooms.Update(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

