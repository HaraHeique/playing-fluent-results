namespace FluentResultTests.Models
{
    public abstract class Entity
    {
        protected Entity() : this(Guid.NewGuid()) { }

        protected Entity(Guid id) => this.Id = id;

        public Guid Id { get; protected set; }

        public bool IsTransient() => this.Id == default(Guid);

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Entity)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            
            return item.Id == this.Id;
        }

        public override int GetHashCode() => this.Id.GetHashCode();

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}
