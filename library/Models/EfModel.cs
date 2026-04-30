using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class EFModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Наименование должно быть заполнено.")]
        public string? Name { get; set; }
    }
}
