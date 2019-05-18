using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public	class vMVendorPurchaseModel
	{
		public string Message { get; set; }
		public int Status { get; set; }
		public List<VendorPurchaseModel> Detail = new List<VendorPurchaseModel>();
	}
}
