using MediatR;
using Note.Infrastructure.Interfaces;

namespace Note.Application.Commands.DeleteNotepadCommand
{
    public class DeleteNotepadCommandHandler : IRequestHandler<DeleteNotepadCommand,bool>
    {
        private readonly INotepadRepository notepadRepository;

        public DeleteNotepadCommandHandler(INotepadRepository notepadRepository)
        {
            this.notepadRepository = notepadRepository;
        }

        public async Task<bool> Handle(DeleteNotepadCommand request, CancellationToken cancellationToken)
        {
            await notepadRepository.DeleteNotepadAsync(request.Id);

            return true;
        }
    }
}