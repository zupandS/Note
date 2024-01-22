using AutoMapper;
using MediatR;
using Note.Core.Entities;
using Note.Infrastructure.Interfaces;

namespace Note.Application.Commands.UpdateNotepadCommand
{
    public class UpdateNotepadCommandHandler : IRequestHandler<UpdateNotepadCommand,bool>
    {
        private readonly INotepadRepository notepadRepository;
        
        private readonly IMapper mapper;

        public UpdateNotepadCommandHandler(INotepadRepository notepadRepository, IMapper mapper)
        {
            this.notepadRepository = notepadRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateNotepadCommand request, CancellationToken cancellationToken)
        {
            var notepad = mapper.Map<Notepad>(request);
            await notepadRepository.UpdateNotepadAsync(notepad);

            return true;
        }

    }
}