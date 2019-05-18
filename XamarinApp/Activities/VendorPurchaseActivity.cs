using System;
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
using Models.ViewModels;
using Newtonsoft.Json.Linq;
using Repository;
using static XamarinApp.Adapter.VendorPurchaseAdapterViewHolder;

namespace XamarinApp.Activities
{
	[Activity(Label = "VendorPurchaseActivity")]
	public class VendorPurchaseActivity : Activity
	{
		private TextView FromDate, toDate;
		private Button btnLoad;
		private EditText editTextfromdate , editTextToDate;
		RecyclerView mRecycleView;
		//VendorPurchaseAdapter vendorPurchaseAdapter;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.UIVendorPurchase);

			FromDate = FindViewById<TextView>(Resource.Id.txtFromDate);
			toDate = FindViewById<TextView>(Resource.Id.txtToDate);

			editTextfromdate = FindViewById<EditText>(Resource.Id.editTextfromdate);
			editTextToDate = FindViewById<EditText>(Resource.Id.editTextToDate);
			btnLoad = FindViewById<Button>(Resource.Id.btnLoadAllStore);
			btnLoad.Click += BtnLoad_Click;
			editTextfromdate.Click += EditTextfromdate_Click;
			editTextToDate.Click += EditTextToDate_Click;
		
		}

		private async void BtnLoad_Click(object sender, EventArgs e)
		{
			try
			{
			    ReturnGenericGet returnGenericGet = new ReturnGenericGet();
			    string CS = PathLink.VendorPurchaseURI;
				JObject obj = await returnGenericGet.GetReturnGeneric(CS + editTextfromdate.ToString() + "&to =" + editTextToDate.ToString());
				vMVendorPurchaseModel vMVendorPurchaseModel = obj.ToObject<vMVendorPurchaseModel>();
				//storeAdapter = new StoreAdapter(vmstore.Detail);
			//vendorPurchaseAdapter = new VendorPurchaseAdapter(vMVendorPurchaseModel.Detail);
			//if (vMVendorPurchaseModel.Status == 1)
			//{
			//	mRecycleView.SetAdapter(vendorPurchaseAdapter);
			//}
			}
			catch (Exception)
			{

				throw;
			} 
		}

		private void EditTextToDate_Click(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			DatePickerDialog dialog = new DatePickerDialog(this, OnDateSet1, today.Year, today.Month - 1, today.Day);
		    
			dialog.DatePicker.MaxDate = today.Millisecond;
			dialog.Show();
		}

		private void EditTextfromdate_Click(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			DatePickerDialog dialog = new DatePickerDialog(this, OnDateSet, today.Year, today.Month - 1, today.Day);
			dialog.DatePicker.MinDate = today.Millisecond;
			dialog.Show();
			

			
		}
		void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			editTextfromdate.Text = e.Date.ToLongDateString();
		}
		void OnDateSet1(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			editTextToDate.Text = e.Date.ToLongDateString();
		}
	}
	}
