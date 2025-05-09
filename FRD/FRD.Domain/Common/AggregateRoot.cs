namespace FRD.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        public DateTime? ModifiedDate { get; set; }

        public AggregateRoot() { }

        public AggregateRoot(TKey id) : base(id)
        {
        }
    }

}
