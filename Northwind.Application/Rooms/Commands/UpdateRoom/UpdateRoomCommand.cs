using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Seats { get; set; }
    }
}
