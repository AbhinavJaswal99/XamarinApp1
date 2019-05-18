using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinApp
{
	[Activity(Label = "DetailActivity")]
	public class DetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TextView txtStoreName, txtAddress, txtCity, txtPhone, txtWareId;

			Button btnLoad;
			base.OnCreate(savedInstanceState);
			//Android.App.AlertDialog dialog = new Android.App.AlertDialog.Builder(this).Create();
			//dialog.SetContentView(Resource.Layout.DialogFragmentCV7);
			SetContentView(Resource.Layout.DialogFragmentCV7);
		//	View view = LayoutInflater.Inflate(Resource.Layout.DialogFragmentCV7, null);
			txtStoreName = FindViewById<TextView>(Resource.Id.txt_StoreNameDailCV7);
			txtAddress = FindViewById<TextView>(Resource.Id.txt_AddressDailCV7);
			txtCity = FindViewById<TextView>(Resource.Id.txt_City_st_DailCV7);
			txtPhone = FindViewById<TextView>(Resource.Id.txt_PhoneCV7);
			txtWareId = FindViewById<TextView>(Resource.Id.txt_WareIdCV7);
			btnLoad = FindViewById<Button>(Resource.Id.btnDoneCV7);

			txtStoreName.Text =  Intent.GetStringExtra("StoreName");
			txtAddress.Text = Intent.GetStringExtra("Address");
			txtCity.Text = Intent.GetStringExtra("City");
			txtPhone.Text = Intent.GetStringExtra("PhoneNo");
			txtWareId.Text = Intent.GetStringExtra("WareId");

			btnLoad.Click +=  delegate
			{
				StartActivity(typeof(MainActivity));
				Finish();
			};
		

		}

	
	}
}