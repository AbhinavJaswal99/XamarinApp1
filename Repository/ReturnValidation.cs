using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    public	class ReturnValidation
	{
		public bool DecimalValidation(String textbox)
		{
			Regex regex = new Regex(@"^\d{1,9}([.]\d{1,2})?$");
		//	Regex regex1 = new Regex(@"^[1-9][0-9]*$");
			if (regex.IsMatch(textbox)/* && regex1.IsMatch(textbox) */)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
