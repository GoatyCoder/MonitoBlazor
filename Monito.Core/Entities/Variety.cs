using System.ComponentModel.DataAnnotations;

namespace Monito.Core.Entities
{
	public class Variety : EntityBase
	{
		[Required(ErrorMessage = "Il codice della varietà è obbligatorio.")]
		public string Code { get; set; }
		[Required(ErrorMessage = "Il nome della varietà è obbligatorio.")]
		public string Name { get; set; }
		public int ProductId { get; set; }
		//public virtual Product Product { get; set; }
	}
}
