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
using XamarinApp.Adapter;

namespace XamarinApp
{
	[Activity(Label = "DetailActivity")]
	public class VendorPurchaseActivity : Activity
	{
		TextView txtStore, txtCostPrice, txtVendorName, txtCustomerName, txtVendorContact,
			txtSellingPrice, txtCustomerContact, txtQuantity, txtRequestBy, txtStatus;
		Button btnAccept, btnReject;
		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.DialogFragmentCV6);
			txtStore = FindViewById<TextView>(Resource.Id.txt_StoreDialCV6);
			txtCostPrice = FindViewById<TextView>(Resource.Id.txt_CostPriceDialCV6);
			txtVendorName = FindViewById<TextView>(Resource.Id.txt_VendorNameDialCV6);
			txtCustomerName = FindViewById<TextView>(Resource.Id.txt_CustomerNameDialCV6);
			txtVendorContact = FindViewById<TextView>(Resource.Id.txt_VendorContactDialCV6);
			txtSellingPrice = FindViewById<TextView>(Resource.Id.txt_SellingPriceDialCV6);
			txtCustomerContact = FindViewById<TextView>(Resource.Id.txt_CustomerContactDialCV6);
			txtSellingPrice = FindViewById<TextView>(Resource.Id.txt_SellingPriceDialCV6);
			txtCustomerContact = FindViewById<TextView>(Resource.Id.txt_CustomerContactDialCV6);
			txtQuantity = FindViewById<TextView>(Resource.Id.txt_QuantityDialCV6);
			txtRequestBy = FindViewById<TextView>(Resource.Id.txt_RequestByDialCV6);
			txtStatus = FindViewById<TextView>(Resource.Id.txt_StatusDialCV6);

		   
			
			txtStore.Text = Intent.GetStringExtra("Store");
			txtCostPrice.Text = Intent.GetStringExtra("Cost");
			txtVendorName.Text = Intent.GetStringExtra("VendorName");
			txtCustomerName.Text = Intent.GetStringExtra("CustomerName");
			txtVendorName.Text = Intent.GetStringExtra("VendorContact");
			txtSellingPrice.Text = Intent.GetStringExtra("SellingPrice");
			txtCustomerContact.Text = Intent.GetStringExtra("CustomerContact");
			txtQuantity.Text = Intent.GetStringExtra("Quantity");
			txtRequestBy.Text = Intent.GetStringExtra("RequestBy");
			txtStatus.Text = Intent.GetStringExtra("Status");


		}
	}
}