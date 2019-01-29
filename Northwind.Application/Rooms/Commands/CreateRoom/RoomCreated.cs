using MediatR;
using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class RoomCreated : INotification
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Seats { get; set; }

        public class RoomCreatedHandler : INotificationHandler<RoomCreated>
        {
            private readonly INotificationService notification;

            public RoomCreatedHandler(INotificationService notification)
            {
                this.notification = notification;
            }

            public async Task Handle(RoomCreated notification, CancellationToken cancellationToken)
            {
                await this.notification.SendAsync(new Message());
            }
        }
    }
}

