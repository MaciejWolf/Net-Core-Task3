using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Id).Length(5).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Floor).NotNull();
            RuleFor(x => x.Seats).NotNull();
        }
    }
}
