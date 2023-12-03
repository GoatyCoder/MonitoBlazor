using System.ComponentModel.DataAnnotations;

namespace Monito.Core.Entities
{
	public class Product : EntityBase
	{
		//[Required(ErrorMessage = "Il codice del prodotto è obbligatorio.")]
		public string Code { get; set; }
		//[Required(ErrorMessage = "Il nome del prodotto è obbligatorio.")]
		public string Name { get; set; }
		//public ICollection<Variety> Varieties { get; set; } = new List<Variety>();
	}
}
