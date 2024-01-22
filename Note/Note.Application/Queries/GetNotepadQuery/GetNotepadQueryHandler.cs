using AutoMapper;
using MediatR;
using Note.Application.Responses;
using Note.Infrastructure.Interfaces;

namespace Note.Application.Queries.GetNotepadQuery
{
    public class GetNotepadQueryHandler : IRequestHandler<GetNotepadQuery,NotepadResponse>
    {
        private readonly INotepadRepository notepadRepository;

        private readonly IMapper mapper;

        public GetNotepadQueryHandler(INotepadRepository notepadRepository,IMapper mapper)
        {
            this.notepadRepository = notepadRepository;
            this.mapper = mapper;
        }

        public async Task<NotepadResponse> Handle(GetNotepadQuery request, CancellationToken cancellationToken)
        {
            var notepad = await notepadRepository.GetNotepadAsync(request.Id);
            var result = mapper.Map<NotepadResponse>(notepad);

            return result;
        }
    }
}