namespace Monito.Core.Entities
{
	public class Article : EntityBase
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Ean { get; set; }
		public int ProductID { get; set; }
	}
}
