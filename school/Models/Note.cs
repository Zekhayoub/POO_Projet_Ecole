namespace school.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Activity { get; set; }
        public string NoteCote { get; set; } // Ajout de la propriété NoteCote
    }
}
