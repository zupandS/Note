using Note.Core.Entities;

namespace Note.Infrastructure.Interfaces
{
    public interface INotepadRepository
    {
        Task AddNotepadAsync(Notepad notepad);

        Task<IEnumerable<Notepad>> GetNotepadsAsync(string title);

        Task<Notepad> GetNotepadAsync(long id);

        Task UpdateNotepadAsync(Notepad notepad);
        
        Task DeleteNotepadAsync(long id);
    }
}