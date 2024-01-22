namespace Note.Core.Entities
{
    public class Notepad
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public string Text { get; set; } = null!;
        
        public bool Status { get; set; }
    }
}