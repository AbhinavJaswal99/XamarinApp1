﻿using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public	class vMGetDateModel
	{
		public int Status { get; set; }
		public string Message { get; set; }
		public List<GetDateModel> Detail = new List<GetDateModel>();
	}
}
