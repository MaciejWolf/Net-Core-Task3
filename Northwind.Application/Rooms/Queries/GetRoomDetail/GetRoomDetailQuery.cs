using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Queries.GetRoomDetail
{
    public class GetRoomDetailQuery : IRequest<RoomDetailModel>
    {
        public string Id { get; set; }
    }
}
