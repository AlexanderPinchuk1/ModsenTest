using MeetupAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.ViewModels
{
    public class MeetupViewModel
    {
        [Guid]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Theme { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; }

        [Speakers]
        public List<string>? Speakers { get; set; }

        [Range(typeof(DateTime), "1/1/2000", "1/1/2100")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string? Place { get; set; }
    }
}
