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
using Models.Models;
using static Android.Content.ClipData;
using static Android.Support.V7.Widget.RecyclerView;

namespace XamarinApp.Adapter
{
	public class StoreAdapterViewHolder : RecyclerView.ViewHolder
	{
		public View itemview { get; set; }
		public TextView Heading1 { get; set; }
		public TextView Heading2 { get; set; }
		public TextView Heading3 { get; set; }
		public TextView Heading4 { get; set; }
		public TextView Heading5 { get; set; }
	

		public StoreAdapterViewHolder(View itemView) : base(itemView)
		{		
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.txtname1);
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.txtstore_name2);
			Heading3 = itemView.FindViewById<TextView>(Resource.Id.txtaddress3);
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.txtcity_st_zip4);
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.txtPhone5);
			Heading5 = itemView.FindViewById<TextView>(Resource.Id.txtWareId6);

			this.itemview = itemview;
		}
	}
	public class StoreAdapter : RecyclerView.Adapter
	{
	
		Context context;

		public List<StoreModel> lstStoreModel = new List<StoreModel>();
		

		public StoreAdapter(List<StoreModel> storeModels)
		{			
			this.lstStoreModel = storeModels;
		}
		public StoreAdapter(Context context)
		{
			this.context = context;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			StoreAdapterViewHolder adapterViewHolder = holder as StoreAdapterViewHolder;
			adapterViewHolder.Heading1.Text = lstStoreModel[position].NAME;
			adapterViewHolder.Heading2.Text = lstStoreModel[position].STORE_NAME;
			adapterViewHolder.Heading3.Text = lstStoreModel[position].ADDRESS;
			adapterViewHolder.Heading4.Text = lstStoreModel[position].CITY_ST_ZIP;
			adapterViewHolder.Heading5.Text = lstStoreModel[position].WAREID;
		
		}
		public override int ItemCount
		{
			get { return lstStoreModel.Count; }
		}

		public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate( Resource.Layout.cardview1 ,  parent, false);
			
			context = parent.Context;
			try
			{
                     foreach(var store1 in lstStoreModel)
                     {
				    TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txtname1);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txtstore_name2);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtaddress3);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtcity_st_zip4);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtPhone5);
					TextView textView6 = itemview.FindViewById<TextView>(Resource.Id.txtWareId6);
					textView1.Text = store1.NAME;
					textView2.Text = store1.STORE_NAME;
					textView3.Text = store1.ADDRESS;
					textView4.Text = store1.CITY_ST_ZIP;
					textView5.Text = store1.PHONE;
					textView6.Text = store1.WAREID;
				     }
	           
		                       
				itemview.Click += (sender, e) =>
				{
					TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txtname1);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txtstore_name2);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtaddress3);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtcity_st_zip4);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtPhone5);
					TextView textView6 = itemview.FindViewById<TextView>(Resource.Id.txtWareId6);
					AlertDialog.Builder dialog = new AlertDialog.Builder(context);
					AlertDialog alert = dialog.Create();

					alert.SetMessage(textView2.Text + "\n" + "ADDRESS - " + textView3.Text
							+ "\n" + "CITY_ST_ZIP - " + textView4.Text + "\n" + "PHONE -  " + textView5.Text);



					alert.Show();
				};
			}
			catch(Exception )
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new StoreAdapterViewHolder(itemview);

		}
	}
}