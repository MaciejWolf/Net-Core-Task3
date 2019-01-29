using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Application.Rooms.Queries.GetRoomDetail
{
    public class RoomDetailModel
    {
        public string Id { get; set; }
        public int Floor { get; set; }
        public int Seats { get; set; }

        public static Expression<Func<Room, RoomDetailModel>> Projection
        {
            get
            {
                return room => new RoomDetailModel
                {
                    Id = room.Id,
                    Floor = room.Floor,
                    Seats = room.Seats
                };
            }
        }

        public static RoomDetailModel Create(Room room)
        {
            return Projection.Compile().Invoke(room);
        }
    }

   
}
