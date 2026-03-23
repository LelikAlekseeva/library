using library.Models;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class Readers : EFModel
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
