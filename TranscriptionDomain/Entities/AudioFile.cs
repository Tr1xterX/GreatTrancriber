using System.ComponentModel.DataAnnotations.Schema;

namespace Transcription.Domain.Entities
{
    public class AudioFile : Entity
    {
        public string Name { get; set; }

        public bool IsCompleted { get; set; }
        public string Description { get; set; }

        public DateTime LoadDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
