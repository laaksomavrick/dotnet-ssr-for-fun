using Microsoft.EntityFrameworkCore;


namespace SsrExample.Data
{
    public class FolderContext : DbContext
    {
        public FolderContext(
            DbContextOptions<FolderContext> options)
            : base(options)
        {
        }

        public DbSet<SsrExample.Models.Folder> Folder { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=ssrexample;Username=postgres");
    }
    
}