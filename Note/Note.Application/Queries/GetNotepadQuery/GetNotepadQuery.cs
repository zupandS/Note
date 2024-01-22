using MediatR;
using Note.Application.Responses;

namespace Note.Application.Queries.GetNotepadQuery
{
    public class GetNotepadQuery : IRequest<NotepadResponse>
    {
        public GetNotepadQuery(long id)
        {
            Id = id;
        }
        
        public long Id { get; set; }
    }
}