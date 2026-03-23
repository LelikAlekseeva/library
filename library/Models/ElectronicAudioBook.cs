namespace library.Models
{
    public class ElectronicAudioBook : EFModel
    {
        public string? Title { get; set; }
        public Author Author { get; set; } = new Author();
        public int Language { get; set; }
        public int Genre { get; set; }
        public List<ElectronicAudioBook>? ElectronicAudioBooks { get; set; }


    }
}
