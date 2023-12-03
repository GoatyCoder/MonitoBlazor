using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monito.Core.Entities
{
	public class Pedana : EntityBase
	{
		public int ProductId { get; set; }
		public int VarietyId { get; set; }
		public int ArticleId { get; set; }
		public int SecondaryPackagingId { get; set; }
		public int Colli { get; set; }
	}
}
