using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace library.Models
{
    public class ElectronicAudioBook : EFModel
    {
        public string? Title { get; set; }
        //[Required(ErrorMessage = "Требуется автор.")]
       // [JsonIgnore]
        public Author Author { get; set; } = new Author();
        public int AuthorID { get; set; }
        //[Range(1000, 2100, ErrorMessage = "Год должен быть между 1000 и 2100.")]
        public string Language { get; set; }
        public string Genre { get; set; }
        public List<ElectronicAudioBook>? ElectronicAudioBooks { get; set; }


    }
}
