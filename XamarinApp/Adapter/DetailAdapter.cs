using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FragmentTransaction = Android.Support.V4.App.Fragment;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Models.Models;
using XamarinApp.Fragments;
using static Android.Support.V7.Widget.RecyclerView;

namespace XamarinApp.Adapter
{
	public class DetailAdapterViewHolder : RecyclerView.ViewHolder
	{
		public View itemview { get; set; }
		public TextView Heading1 { get; set; }
		public TextView Heading2 { get; set; }

		public DetailAdapterViewHolder(View itemView) : base(itemView)
		{
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.txt_NAMECV5);
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.txt_StoreNameCV5);

			this.itemview = itemview;
		}
	}

	public class DetailAdapter : RecyclerView.Adapter
	{
		Context context;

		public List<StoreModel> lstStoreModel = new List<StoreModel>();


		public DetailAdapter(List<StoreModel> storeModels)
		{
			this.lstStoreModel = storeModels;
		}
		public DetailAdapter(Context context)
		{
			this.context = context;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			DetailAdapterViewHolder adapterViewHolder = holder as DetailAdapterViewHolder;
			adapterViewHolder.Heading1.Text = lstStoreModel[position].NAME;
			adapterViewHolder.Heading2.Text = lstStoreModel[position].STORE_NAME;
		}
		public override int ItemCount
		{
			get { return lstStoreModel.Count; }
		}
		public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView5, parent, false);

			context = parent.Context;
			try
			{
				foreach (var store1 in lstStoreModel)
				{
					TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txt_NAMECV5);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txt_StoreNameCV5);
				
					textView1.Text = store1.NAME;
					textView2.Text = store1.STORE_NAME;
					
				}

				itemview.Click += (sender, e) =>
				{
					onclick(lstStoreModel[viewType]);
				};
				//itemview.Click += (sender, e) =>
				//{


				//	View itemview1 = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DialogFragmentCV6, parent, false);
					
				//		context = parent.Context;
				//	try
				//	{
				//		//foreach (var store2 in lstStoreModel)
				//		//{
				//		//	TextView txt1 = itemview1.FindViewById<TextView>(Resource.Id.txt_StoreNAMEDialCV6);
				//		//	TextView txt2 = itemview1.FindViewById<TextView>(Resource.Id.txt_AddressDialCV6);
				//		//	TextView txt3 = itemview1.FindViewById<TextView>(Resource.Id.txt_City_ST_DialCV6);
				//		//	TextView txt4 = itemview1.FindViewById<TextView>(Resource.Id.txt_PhoneDialCV6);
				//		//	TextView txt5 = itemview1.FindViewById<TextView>(Resource.Id.txt_StoretypeDialCV6);
				//		//	TextView txt6 = itemview1.FindViewById<TextView>(Resource.Id.txt_DEF_AreaDialCV6);
				//		//	TextView txt7 = itemview1.FindViewById<TextView>(Resource.Id.txt_WarIdDialCV6);

				//		//	txt1.Text = store2.STORE_NAME;
				//		//	txt2.Text = store2.ADDRESS;
				//		//	txt3.Text = store2.CITY_ST_ZIP;
				//		//	txt4.Text = store2.PHONE;
				//		//	txt5.Text = store2.STORE_TYPE;
				//		//	txt6.Text = store2.DEF_AREA;
				//		//	txt7.Text = store2.WAREID;
				//		//	AlertDialog.Builder dialog = new AlertDialog.Builder(context);
				//		//	AlertDialog alert = dialog.Create();

				//		//	alert.SetMessage(txt1.Text + "\n" + "ADDRESS - " + txt2.Text
				//		//		+ "\n" + "CITY ZIP-CODE - " + txt3.Text + "\n" + "PHONE -  " + txt4.Text + "\n" +
				//		//		"Store_Type" + txt5.Text + "\n" + "Def_Area" + txt6.Text + "\n" + "WareID - " + txt7.Text);
				//		////alert.SetButton("Accept", (c, ev) =>
				//		////{
				//		////
				//		////});
				//		////alert.SetButton2("Reject", (c, ev) => { });
				//		////
				//		//	alert.Show();

				//		//	break;
				//		//}
				//	}

				//	catch (Exception)
				//	{

				//		throw;
				//	}

				//	//TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txt_NAMECV5);
				//	//TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txt_StoreNameCV5);
				//	//
				//	//AlertDialog alert = dialog.Create();
				//	//
				//	//
				//	//alert.SetMessage(textView2.Text );
				//	//




				//};
			}
			catch (Exception)
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new DetailAdapterViewHolder(itemview);

		}

		private void onclick(StoreModel storeModel)
		{
			Intent intent = new Intent(context, typeof(DetailActivity));
			intent.PutExtra("StoreName", storeModel.STORE_NAME);
			intent.PutExtra("Address", storeModel.ADDRESS);
			intent.PutExtra("City", storeModel.CITY_ST_ZIP);
			intent.PutExtra("PhoneNo", storeModel.PHONE);
			intent.PutExtra("WareId", storeModel.WAREID);
			context.StartActivity(intent);
		}
	}
}