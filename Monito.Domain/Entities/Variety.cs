namespace Monito.Domain.Entities
{
    public class Variety : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} ({Code})";
        }
    }
}
