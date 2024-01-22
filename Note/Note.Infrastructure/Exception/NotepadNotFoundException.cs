namespace Note.Infrastructure.Exception
{
    public class NotepadNotFoundException : System.Exception
    {
        public NotepadNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
        
        public string ErrorMessage { get; set; }
    }
}