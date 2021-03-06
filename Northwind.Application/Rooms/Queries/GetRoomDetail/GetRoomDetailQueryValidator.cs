﻿using FluentValidation;

namespace Northwind.Application.Rooms.Queries.GetRoomDetail
{
    public class GetRoomDetailQueryValidator : AbstractValidator<GetRoomDetailQuery>
    {
        public GetRoomDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().Length(5);
        }
    }
}
