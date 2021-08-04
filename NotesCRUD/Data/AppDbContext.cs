using Microsoft.EntityFrameworkCore;



namespace NotesCRUD.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }
        public DbSet<Notes> Notes { get; set; }
    }
}
