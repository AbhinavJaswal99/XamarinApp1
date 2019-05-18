using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Repository;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;
using Models.ViewModels;
using XamarinApp.Adapter;
using Models.Models;

namespace XamarinApp.Fragments
{
	public class UIStoreMinimumFragment : Fragment
	{
		View view;
		Button btnSearch;
		RecyclerView mrecyclerview;
		EditText editSearch;
		RecyclerView.LayoutManager mLayoutManager;
		StoreMinAdapter StoreMinAdapter;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			
		}

		public static UIStoreMinimumFragment NewInstance()
		{
			UIStoreMinimumFragment frag1 = new UIStoreMinimumFragment { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIStoreMinimum, container, false);
				btnSearch = view.FindViewById<Button>(Resource.Id.btnSearch);
				editSearch = view.FindViewById<EditText>(Resource.Id.txtSearch);
				mrecyclerview = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewUIStoremin);
				mLayoutManager = new LinearLayoutManager(Context);
				mrecyclerview.SetLayoutManager(mLayoutManager);
				btnSearch.Click += BtnSearch_Click;
				return view;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		
		}

		private async void BtnSearch_Click(object sender, EventArgs e)
		{
			try
			{		
					ReturnGenericGet returnGenericGet = new ReturnGenericGet();
					string CS = PathLink.StoreMinimumURI;
					JObject obj = await returnGenericGet.GetReturnGeneric(CS + editSearch.Text.ToUpper());
					//StoreMinModel storeminmodel = obj.ToObject<StoreMinModel>();
					vMStoreMin vMStoreMin = obj.ToObject<vMStoreMin>();
					StoreMinAdapter = new StoreMinAdapter(vMStoreMin.Detail);
					if (vMStoreMin.Status == 1)
					{
						mrecyclerview.SetAdapter(StoreMinAdapter);
					}
			}
			catch (Exception ex)
			{

				//Toast.MakeText(Context, Convert.ToInt32(ex), ToastLength.Short).Show();
				Toast.MakeText(Context, "Enter values", ToastLength.Long).Show();
				throw ex;
					
				
				
			}
		}
	}
}