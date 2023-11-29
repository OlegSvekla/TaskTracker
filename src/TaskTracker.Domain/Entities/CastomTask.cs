namespace TaskTracker.Domain.Entities
{
    public class CastomTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}