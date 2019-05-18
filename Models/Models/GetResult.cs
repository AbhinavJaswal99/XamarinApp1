using Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GetResult : IResult
	{
		public int Status { get; set; }
		public string Message { get; set; }
	}
}
