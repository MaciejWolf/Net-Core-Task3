using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Queries.GetRoomDetail
{
    public class GetRoomDetailQueryHandler : IRequestHandler<GetRoomDetailQuery, RoomDetailModel>
    {
        private readonly NorthwindDbContext context;

        public GetRoomDetailQueryHandler(NorthwindDbContext context)
        {
            this.context = context;
        }

        public async Task<RoomDetailModel> Handle(GetRoomDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Rooms
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return new RoomDetailModel
            {
                Id = entity.Id,
                Floor = entity.Floor,
                Seats = entity.Seats
            };
        }
    }
}
