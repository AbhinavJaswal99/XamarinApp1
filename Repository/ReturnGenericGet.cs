using Models.Models;
using Models.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReturnGenericGet
	{
		public async Task<JObject> GetReturnGeneric(string url)
		{
			vMStore vmStore = new vMStore();
			GetResult getResult = new GetResult();
			JObject obj = new JObject();
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					
					HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
					if (response.IsSuccessStatusCode)
					{
						string Data = response.Content.ReadAsStringAsync().Result.ToString();
						obj = JObject.Parse(Data);
						return obj;
					}
					else
					{
						getResult.Message = response.StatusCode + "error reason : " + response.ReasonPhrase;
						return null;
						
					}
				//getResult.Status = 1;
				//getResult.Message = "Store are successfully loaded";
					
				}
			}
			catch (Exception ex)
			{
				getResult.Status = 0;
				getResult.Message = ex.Message.ToString();
				return null;

			}
		}
	}
}
