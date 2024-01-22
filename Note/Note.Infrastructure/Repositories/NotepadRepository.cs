using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Note.Core.Entities;
using Note.Infrastructure.Exception;
using Note.Infrastructure.Interfaces;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;

namespace Note.Infrastructure.Repositories
{
    public class NotepadRepository : INotepadRepository
    {
        private readonly DataContext dataContext;

        public NotepadRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddNotepadAsync(Notepad notepad)
        {
            await dataContext.Notepad.AddAsync(notepad);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteNotepadAsync(long id)
        {
            var notepad = await dataContext.Notepad.FirstAsync(notepad => notepad.Id == id);

            if (notepad == null)
            {
                throw new NotepadNotFoundException("Error ! Note does not exist ");
            }
            
            dataContext.Notepad.Remove(notepad);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Notepad> GetNotepadAsync(long id)
        {
            var notepad = await dataContext.Notepad.AsNoTracking().FirstAsync(notepad => notepad.Id == id);

            if (notepad == null)
            {
                throw new NotepadNotFoundException("Error ! Note does not exist ");
            }

            return notepad;
        }

        public async Task<IEnumerable<Notepad>> GetNotepadsAsync(string title)
        {
            var notepad = await dataContext.Notepad.Where(notepad => notepad.Title.ToLower().Contains(title)).AsNoTracking().ToListAsync();

            if (notepad.Count == 0)
            {
                throw new NotepadNotFoundException("Error ! Notes does not exist ");
            }

            return notepad;
        }

        public async Task UpdateNotepadAsync(Notepad notepad)
        {
            var result = await dataContext.Notepad.FirstOrDefaultAsync(n => n.Id == notepad.Id);
 
            if (result == null)
            {
                throw new NotepadNotFoundException("Error ! Note does not exist ");
            }

            result.Title = notepad.Title;
            result.Text = notepad.Text;
            result.Status = notepad.Status;

            await dataContext.SaveChangesAsync();
        }
    }
}