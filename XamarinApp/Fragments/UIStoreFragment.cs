using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using XamarinApp.Adapter;
using Repository;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;
using Models.ViewModels;
using Models.Models;
using System.Threading.Tasks;
using Felipecsl.GifImageViewLibrary;

namespace XamarinApp.Fragments
{
	public class UIStoreFragment : Fragment
	{

		Spinner spinnervalue;
		Button btnLoad;
		RecyclerView mRecycleView;
		StoreAdapter storeAdapter;
		RecyclerView.LayoutManager mLayoutManager;
		View view;
		
		


		public   override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			
		}

		public static UIStoreFragment NewInstance()
		{
		    UIStoreFragment frag1 = new UIStoreFragment { Arguments = new Bundle() };
			return frag1;
		}

		public  override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIStoreModel, container, false);
				spinnervalue = view.FindViewById<Spinner>(Resource.Id.spinnervalue1);
				mRecycleView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView123);
				
				btnLoad = view.FindViewById<Button>(Resource.Id.btnLoad);
				mLayoutManager = new LinearLayoutManager(Context);
				mRecycleView.SetLayoutManager(mLayoutManager);
				LoadSeries();
				btnLoad.Click += BtnLoad_Click;
				return view;
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private async void BtnLoad_Click(object sender, EventArgs e)
		{
			try
			{
				ReturnGenericGet returnGenericGet = new ReturnGenericGet();
				string CS = PathLink.StoreURI;
				JObject obj = await returnGenericGet.GetReturnGeneric(CS);
				vMStore vMStore = obj.ToObject<vMStore>();
				storeAdapter = new StoreAdapter(vMStore.Detail);
				if(vMStore.Status == 1)
				{
					mRecycleView.SetAdapter(storeAdapter);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task LoadSeries()
		{
			try
			{
				
				//spinnervalue = view1.FindViewById<Spinner>(Resource.Id.spinnervalue1);
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

					ArrayAdapter arrayAdapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleSpinnerItem, Name);
					spinnervalue.Adapter = arrayAdapter;

				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
		}
	}
}