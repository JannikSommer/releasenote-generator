
namespace ReleaseNoteGenerator
{
    public class Configuration
    {
        public List<Section> Sections { get; set; } = new List<Section>();
    }

    public class Section
    {
        public string Label { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
    }
}
