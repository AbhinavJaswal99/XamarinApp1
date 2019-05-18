using Models.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class ReturnGenericPost
	{
		public async Task<JObject> ReturnGeneralPosMeth(string url, HttpContent model)
		{
			GetResult result = new GetResult();
			JObject obj = new JObject();

			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Clear();
				//	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage response = await client.PostAsync(url, model).ConfigureAwait(false);
					if (response.IsSuccessStatusCode)
					{
						string Data = response.Content.ReadAsStringAsync().Result.ToString();
						obj = JObject.Parse(Data);
						return obj;
					}
					else
					{
						result.Message = response.StatusCode + "reason : " + response.ReasonPhrase;
						result.Status = 0;
						result.Message = "No stores successfully";
						return null;

					}
				}
			}
			catch (Exception ex)
			{
				result.Status = 0;
				result.Message = ex.Message.ToString();
				return null;


			}
		}
	}
}
