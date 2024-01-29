using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPoints.entities
{
	public class BusinessPoint
	{
		public int id {  get; set; }
		public int buildingId { get; set; }
		public int businessPublishCard {  get; set; }
		public string? pointName { get; set; }
	}
}
