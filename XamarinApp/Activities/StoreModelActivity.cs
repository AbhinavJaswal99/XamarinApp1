using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Models.ConnectionSt;
using Models.Models;
using Models.ViewModels;
using Newtonsoft.Json.Linq;
using Repository;
using XamarinApp.Adapter;

namespace XamarinApp.Activities
{
	[Activity(Label = "StoreModelActivity")]
	public class StoreModelActivity : Activity
	{
		public bool isFirstLoad { get; set; }
		Spinner spinnervalue;
		Button btnLoad;
		RecyclerView mRecycleView;
		StoreAdapter storeAdapter;
		RecyclerView.LayoutManager mLayoutManager;
		

		protected async  override void OnCreate(Bundle savedInstanceState)
		{
			try
			{
				
				base.OnCreate(savedInstanceState);
				
		     	SetContentView(Resource.Layout.UIStoreModel);
		     	mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView123);
		     	spinnervalue = FindViewById<Spinner>(Resource.Id.spinnervalue1);
			
				mLayoutManager = new LinearLayoutManager(this);
				mRecycleView.SetLayoutManager(mLayoutManager);
				List<string> Name = new List<string>();
				ReturnGenericGet returnGenericGet = new ReturnGenericGet();
				string CS = PathLink.StoreURI;
				JObject obj = await returnGenericGet.GetReturnGeneric(CS);
				vMStore vmStore = obj.ToObject<vMStore>();
				if (vmStore.Status == 1)
				{
					foreach (var itms in vmStore.Detail)
					{
						Name.Add(itms.NAME);
					}
					ArrayAdapter arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, Name);
					spinnervalue.Adapter = arrayAdapter;
				}

			btnLoad = FindViewById<Button>(Resource.Id.btnLoad);
			btnLoad.Click += BtnLoad_Click;
			//	textSearch.TextChanged += TextSearch_TextChanged;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		List<StoreModel> globalDetails = new List<StoreModel>();

		
		private async void BtnLoad_Click(object sender, EventArgs e)
		{
			try
			{
				ReturnGenericGet returnGenericGet = new ReturnGenericGet();
				string CS = PathLink.StoreURI;
			//	List<string> Name = new List<string>();
				JObject obj = await returnGenericGet.GetReturnGeneric(CS);
				vMStore vmstore = obj.ToObject<vMStore>();
				storeAdapter = new StoreAdapter(vmstore.Detail);
				if (vmstore.Status == 1)
				{
					mRecycleView.SetAdapter(storeAdapter);
				}
			}
			catch(Exception)
			{
				throw;
			}
		}
	}
}