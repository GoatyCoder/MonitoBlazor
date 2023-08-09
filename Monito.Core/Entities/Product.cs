namespace Monito.Core.Entities
{
	public class Product : EntityBase
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public IEnumerable<Variety> Varieties { get; set; }
	}
}
