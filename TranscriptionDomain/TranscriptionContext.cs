using Microsoft.EntityFrameworkCore;
using Transcription.Domain.Entities;

namespace Transcription.Domain
{
    public class TranscriptionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }

        //public DbSet<TextFile> TextFiles { get; set; }

        public TranscriptionContext(DbContextOptions options) : base(options) 
        {
        }
    }
}
