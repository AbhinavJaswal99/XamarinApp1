using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinApp.Adapter;
using Android.Support.V7.Widget;
using Repository;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;
using Models.ViewModels;
using Fragment = Android.Support.V4.App.Fragment;

namespace XamarinApp.Fragments
{
	public class UIVendorPurchaseFragment : Fragment
	{
		View view;
		Button btnLoadAlStore;
		EditText edtxtfromdate, edtxttodate;
		VendorPurchaseAdapter vendorPurchaseAdapter;
		RecyclerView mrecyclerview;
		LinearLayoutManager mlayoutmanager;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

        }

		public static UIVendorPurchaseFragment NewInstance()
		{
			UIVendorPurchaseFragment frag1 = new UIVendorPurchaseFragment { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIVendorPurchase, container, false);
				btnLoadAlStore = view.FindViewById<Button>(Resource.Id.btnLoadAllStore);
				edtxtfromdate = view.FindViewById<EditText>(Resource.Id.editTextfromdate);
				edtxttodate = view.FindViewById<EditText>(Resource.Id.editTextToDate);
				mrecyclerview = view.FindViewById<RecyclerView>(Resource.Id.CV2RecyclerView2);
				mlayoutmanager = new LinearLayoutManager(this.Context);
				mrecyclerview.SetLayoutManager(mlayoutmanager);

				edtxtfromdate.Click += (sender, e) => {
					DateTime today = DateTime.Today;
					
					DatePickerDialog dialog = new DatePickerDialog(Context, OnDateSet, today.Year - 1, today.Month - 1, today.Day);
				
					dialog.DatePicker.MinDate = today.Millisecond;
					dialog.Show();
				};
				void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
				{
					edtxtfromdate.Text = e.Date.ToString("yyyy-MM-dd");
					
				}

				void OnDateSet1(object sender, DatePickerDialog.DateSetEventArgs e)
				{
					
					edtxttodate.Text = e.Date.ToString("yyyy-MM-dd");

				}

				edtxttodate.Click += (sender, e) => {
					DateTime today = DateTime.Today;
					DatePickerDialog dialog = new DatePickerDialog(Context, OnDateSet1, today.Year, today.Month - 1, today.Day);
					dialog.DatePicker.MinDate = today.Millisecond;
					dialog.Show();
				};

				btnLoadAlStore.Click += BtnLoadAlStore_Click;
				return view;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
			
		}

		private async void BtnLoadAlStore_Click(object sender, EventArgs e)
		{
			try
			{
				ReturnGenericGet returnGenericGet = new ReturnGenericGet();
				string CS = PathLink.VendorPurchaseURI;
				JObject obj = await returnGenericGet.GetReturnGeneric(CS + edtxtfromdate.Text + "&to=" + edtxttodate.Text);
				vMVendorPurchaseModel vMVendorPurchaseModel = obj.ToObject<vMVendorPurchaseModel>();
				vendorPurchaseAdapter = new VendorPurchaseAdapter(vMVendorPurchaseModel.Detail);
				if(vMVendorPurchaseModel.Status == 1)
				{
					mrecyclerview.SetAdapter(vendorPurchaseAdapter);
				}
			}
			catch (Exception ex)
			{
				Toast.MakeText(Context, "Enter values", ToastLength.Long).Show();
				throw ex;
			}
		}
	}
}