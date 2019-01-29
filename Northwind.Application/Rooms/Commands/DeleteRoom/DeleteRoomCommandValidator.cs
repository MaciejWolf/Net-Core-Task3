using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(x => x.Id).Length(5).NotEmpty();
        }
    }
}
