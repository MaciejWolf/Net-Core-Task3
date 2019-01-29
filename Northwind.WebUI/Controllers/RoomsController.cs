using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Rooms.Commands.CreateRoom;
using Northwind.Application.Rooms.Commands.DeleteRoom;
using Northwind.Application.Rooms.Commands.UpdateRoom;
using Northwind.Application.Rooms.Queries.GetRoomDetail;
using Northwind.Application.Rooms.Queries.GetRooms;
using Northwind.WebApp.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.WebUI.Controllers
{
    public class RoomsController : BaseController
    {
        // GET api/rooms
        [HttpGet]
        public async Task<ActionResult<RoomsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRoomsListQuery()));
        }

        // GET api/rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailQuery { Id = id }));
        }

        // POST api/rooms
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/rooms/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(string id, [FromBody]UpdateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/rooms/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }
    }
}
