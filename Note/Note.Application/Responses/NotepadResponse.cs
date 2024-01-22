namespace Note.Application.Responses
{
    public class NotepadResponse
    {
        public string Title { get; set; } = null!;
        
        public string Text { get; set; } = null!;

        public bool Status { get; set; }
    }
}