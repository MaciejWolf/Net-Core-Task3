using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public string Id { get; set; }
    }
}
