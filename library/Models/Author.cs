namespace library.Models
{
    public class Author : EFModel
    {
        public List<ElectronicAudioBook> Books { get; set; } = new List<ElectronicAudioBook>();
    }
}
