using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public	class vMStoreMin
	{
		public string Message { get; set; }
		public int Status { get; set; }
		public List<StoreMinModel> Detail = new List<StoreMinModel>();
	}
}
