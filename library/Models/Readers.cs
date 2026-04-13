using library.Models;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class Readers : EFModel
    {
        [Required(ErrorMessage = "Необходимо заполнить имя")]
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public List<ElectronicAudioBook>? ElectronicAudioBooks { get; set; }
    }
}
