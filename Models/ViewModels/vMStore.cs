using Models.Models;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class vMStore
	{
		public string Message { get; set; }
		public int Status { get; set; }
		public List<StoreModel> Detail = new List<StoreModel>();
	}
}
