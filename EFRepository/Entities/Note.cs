using System.ComponentModel.DataAnnotations;

namespace EFRepository.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Notes { get; set; }
    }
}
