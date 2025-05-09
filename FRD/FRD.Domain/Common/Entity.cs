namespace FRD.Domain
{
    public abstract class Entity<TKey> : ISoftDelete
    {
        public DateTime CreateDate { get; set; }
        public TKey Id { get; protected set; }
        public bool IsDeleted { get; set; } 

        public Entity() { }
        public Entity(TKey id) : base()
        {
            Id = id;
            IsDeleted = false;
        }
    }

}
