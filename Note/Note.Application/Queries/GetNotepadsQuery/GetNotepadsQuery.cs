using MediatR;
using Note.Application.Responses;
using Note.Core.Entities;

namespace Note.Application.Queries.GetNotepadsQuery
{
    public class GetNotepadsQuery : IRequest<IEnumerable<Notepad>>
    {
        public GetNotepadsQuery(string title)
        {
            Title = title;
        }
        
        public string Title { get; set; } = null!;
    }
}