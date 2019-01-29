using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsListQueryHandler : IRequestHandler<GetRoomsListQuery, RoomsListViewModel>
    {
        private readonly NorthwindDbContext context;
        private readonly IMapper mapper;

        public GetRoomsListQueryHandler(NorthwindDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RoomsListViewModel> Handle(GetRoomsListQuery request, CancellationToken cancellationToken)
        {
            return new RoomsListViewModel
            {
                Rooms = await context.Rooms.
                        ProjectTo<RoomLookupModel>(mapper.ConfigurationProvider).
                        ToListAsync(cancellationToken)
            };
        }
    }
}
