using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public	class GetDateModel
	{
		public string PO_Number { get; set; }
		public string Purchase_Date { get; set; }
		public string Store { get; set; }
		public string Subtotal { get; set; }
		public string Tax { get; set; }
		public string TOTAL { get; set; }
		public string Vendor { get; set; }
	}
}
