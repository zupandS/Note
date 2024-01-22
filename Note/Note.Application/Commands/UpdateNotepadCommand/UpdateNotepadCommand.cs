using MediatR;

namespace Note.Application.Commands.UpdateNotepadCommand
{
    public class UpdateNotepadCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public string Text { get; set; } = null!;
        
        public bool Status { get; set; }
    }
}