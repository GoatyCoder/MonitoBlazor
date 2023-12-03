namespace Monito.Domain.Entities
{
    public class Product : EntityBase
    {

        public string Name { get; set; }

        public string Code { get; set; }

        //public IEnumerable<Variety> Varieties { get; set; } = Enumerable.Empty<Variety>();

        public override string ToString()
        {
            return $"{Id}: {Name} ({Code})";
        }
    }
}
