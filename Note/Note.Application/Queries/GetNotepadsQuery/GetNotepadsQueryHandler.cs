using AutoMapper;
using MediatR;
using Note.Application.Responses;
using Note.Core.Entities;
using Note.Infrastructure.Interfaces;

namespace Note.Application.Queries.GetNotepadsQuery
{
    public class GetNotepadsQueryHandler : IRequestHandler<GetNotepadsQuery, IEnumerable<Notepad>>
    {
        private readonly IMapper mapper;
        
        private readonly INotepadRepository notepadRepository;

        public GetNotepadsQueryHandler(INotepadRepository notepadRepository, IMapper mapper)
        {
            this.notepadRepository = notepadRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Notepad>> Handle(GetNotepadsQuery request, CancellationToken cancellationToken)
        {
            var notepads = await notepadRepository.GetNotepadsAsync(request.Title);

            return notepads;
        }
    }
}