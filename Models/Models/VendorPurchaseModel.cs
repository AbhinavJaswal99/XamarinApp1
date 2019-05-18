using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public	class VendorPurchaseModel
	{
		public string Cost { get; set; }                       
		public string SELLING_COST { get; set; }
		public string VENDOR_NAME { get; set; }
		public string VENDOR_CONTACT { get; set; }
		public string CUSTOMER_NAME { get; set; }
		public string CUSTOMER_CONTACT { get; set; }
		public string Request_ID { get; set; }
		public string STORE { get; set; }
		public string CODE { get; set; }
		public string Requested_By { get; set; }
		public string Status { get; set; }
		public string Requested_Qty { get; set; }
		public string Approved_QTY { get; set; }
		public string REQUESTED_ON { get; set; }
		public string APPROVED_BY { get; set; }
		public string APPROVED_ON { get; set; }
	}
}
