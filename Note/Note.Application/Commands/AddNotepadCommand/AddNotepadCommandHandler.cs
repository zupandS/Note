using AutoMapper;
using MediatR;
using Note.Core.Entities;
using Note.Infrastructure.Interfaces;

namespace Note.Application.Commands.AddNotepadCommand
{
    public class AddNotepadCommandHandler : IRequestHandler<AddNotepadCommand,bool>
    {
        private readonly INotepadRepository notepadRepository;

        private readonly IMapper mapper;

        public AddNotepadCommandHandler(INotepadRepository notepadRepository,IMapper mapper)
        {
            this.notepadRepository = notepadRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AddNotepadCommand request, CancellationToken cancellationToken)
        {
            var notepad = mapper.Map<Notepad>(request);
            await notepadRepository.AddNotepadAsync(notepad);
            
            return true;
        }
    }
}