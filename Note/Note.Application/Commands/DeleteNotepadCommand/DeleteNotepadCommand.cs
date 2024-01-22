using MediatR;

namespace Note.Application.Commands.DeleteNotepadCommand
{
    public class DeleteNotepadCommand : IRequest<bool>
    {
        public DeleteNotepadCommand(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }
}