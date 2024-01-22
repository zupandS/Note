using MediatR;
using MediatR.Pipeline;

namespace Note.Application.Commands.AddNotepadCommand
{
    public class AddNotepadCommand : IRequest<bool>
    {
        public string Title { get; set; } = null!;
        
        public string Text { get; set; } = null!;
    }
}