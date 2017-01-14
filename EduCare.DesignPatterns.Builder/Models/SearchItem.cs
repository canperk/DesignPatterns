namespace EduCare.DesignPatterns.Builder.Models
{
    public class SearchItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
    }
}
