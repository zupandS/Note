using Microsoft.AspNetCore.Mvc;
using Note.Application.Commands.AddNotepadCommand;
using Note.Application.Queries.GetNotepadQuery;
using MediatR;
using Note.Application.Queries.GetNotepadsQuery;
using Note.Application.Commands.UpdateNotepadCommand;
using Note.Application.Commands.DeleteNotepadCommand;
using Note.Application.Responses;
using Note.Core.Entities;

namespace Note.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class NotepadController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotepadController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("AddNotepad")]
        public async Task<ActionResult<bool>> AddNotepad([FromBody] AddNotepadCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("UpdateNotepad")]
        public async Task<ActionResult<bool>> UpdateNotepad([FromBody] UpdateNotepadCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("DeleteNotepad/{id}")]
        public async Task<ActionResult<bool>> DeleteNotepad([FromRoute] long id)
        {
            var command = new DeleteNotepadCommand(id);
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetNotepad/{id}")]
        public async Task<ActionResult<NotepadResponse>> GetNotepad([FromRoute] long id)
        {
            var query = new GetNotepadQuery(id);
            return Ok(await mediator.Send(query));
        }
        
        [HttpGet("GetNotepads/{title}")]
        public async Task<ActionResult<IEnumerable<Notepad>>> GetNotepads([FromRoute] string title)
        {
            var query = new GetNotepadsQuery(title);
            return Ok(await mediator.Send(query));
        }
    }
}