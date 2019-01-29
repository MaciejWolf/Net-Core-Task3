using MediatR;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Seats { get; set; }

        public class Handler : IRequestHandler<CreateRoomCommand, Unit>
        {
            private readonly NorthwindDbContext context;
            private readonly INotificationService notificationService;
            private readonly IMediator mediator;

            public Handler(
                NorthwindDbContext context,
                INotificationService notificationService,
                IMediator mediator)
            {
                this.context = context;
                this.notificationService = notificationService;
                this.mediator = mediator;
            }

            public async Task<Unit> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                var entity = new Room
                {
                    Id = request.Id,
                    Name = request.Name,
                    Floor = request.Floor,
                    Seats = request.Seats
                };

                context.Rooms.Add(entity);

                await context.SaveChangesAsync(cancellationToken);

                await mediator.Publish(new RoomCreated { Id = entity.Id });

                return Unit.Value;
            }
        }
    }
}
