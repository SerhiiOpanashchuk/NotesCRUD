using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace NotesCRUD.Data
{
    public class NotesService
    {
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public NotesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Notes
        public async Task<List<Notes>> GetAllNotesAsync()
        {
            return await _appDBContext.Notes.ToListAsync();
        }
        #endregion

        #region Insert Notes
        public async Task<bool> InsertNotesAsync(Notes notes)
        {
            await _appDBContext.Notes.AddAsync(notes);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Notes by Id
        public async Task<Notes> GetNotesAsync(int Id)
        {
            Notes notes = await _appDBContext.Notes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return notes;
        }
        #endregion

        #region Update Notes
        public async Task<bool> UpdateNotesAsync(Notes notes)
        {
            _appDBContext.Notes.Update(notes);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteNotes
        public async Task<bool> DeleteNotesAsync(Notes notes)
        {
            _appDBContext.Remove(notes);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
