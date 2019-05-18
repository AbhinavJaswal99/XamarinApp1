using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public 	class vMPOModel
	{
		public int Status { get; set; }
		public string Message { get; set; }
		public List<POModel> Detail = new List<POModel>();
	}
}
