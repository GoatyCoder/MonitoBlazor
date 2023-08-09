namespace Monito.Core.Entities
{
    public class Variety : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
