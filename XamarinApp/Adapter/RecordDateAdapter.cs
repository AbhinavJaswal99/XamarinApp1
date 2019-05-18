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
using static Android.Support.V7.Widget.RecyclerView;

namespace XamarinApp.Adapter
{
	public class RecordDateAdapterViewHolder : RecyclerView.ViewHolder
	{
		public View itemview { get; set; }
		public TextView Heading1 { get; set; }
		public TextView Heading2 { get; set; }
		public TextView Heading3 { get; set; }
		public TextView Heading4 { get; set; }
		public TextView Heading5 { get; set; }
		public TextView Heading6 { get; set; }
		public TextView Heading7 { get; set; }

		public RecordDateAdapterViewHolder(View itemView) : base(itemView)
		{
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.txtPO_NumberCV4);
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.txtPurchase_DateCV4);
			Heading3 = itemView.FindViewById<TextView>(Resource.Id.txtStoreCV4);
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.txtSubTotalCV4);
			Heading5 = itemView.FindViewById<TextView>(Resource.Id.txtTaxCV4);
			Heading6 = itemView.FindViewById<TextView>(Resource.Id.txtTotalCV4);
			Heading7 = itemView.FindViewById<TextView>(Resource.Id.txtVendorCV4);

			this.itemview = itemview;
		}
	}



	public class RecordDateAdapter : RecyclerView.Adapter
	{
		Context context;

		public List<GetDateModel> getDateModels = new List<GetDateModel>();

		

		public RecordDateAdapter(List<GetDateModel> DateModels)
		{
			this.getDateModels = DateModels;
		}

		public RecordDateAdapter(Context context)
		{
			this.context = context;
		}



	

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			RecordDateAdapterViewHolder adapterViewHolder = holder as RecordDateAdapterViewHolder;
			adapterViewHolder.Heading1.Text = getDateModels[position].PO_Number;
			adapterViewHolder.Heading2.Text = getDateModels[position].Purchase_Date;
			adapterViewHolder.Heading3.Text = getDateModels[position].Store;
			adapterViewHolder.Heading4.Text = getDateModels[position].Subtotal;
			adapterViewHolder.Heading5.Text = getDateModels[position].Tax;
			adapterViewHolder.Heading6.Text = getDateModels[position].TOTAL;
			adapterViewHolder.Heading7.Text = getDateModels[position].Vendor;

		}

		 public override int ItemCount
		 {
		 	get { return getDateModels.Count; }
		 }

		public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView4, parent, false);

			context = parent.Context;

			try
			{
				foreach(var getdate in getDateModels)
				{
					TextView textview1 = itemview.FindViewById<TextView>(Resource.Id.txtPO_NumberCV4);
					TextView textview2 = itemview.FindViewById<TextView>(Resource.Id.txtPurchase_DateCV4);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtStoreCV4);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtSubTotalCV4);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtTaxCV4);
					TextView textView6 = itemview.FindViewById<TextView>(Resource.Id.txtTotalCV4);
					TextView textView7 = itemview.FindViewById<TextView>(Resource.Id.txtVendorCV4);
					textview1.Text = getdate.PO_Number;
					textview2.Text = getdate.Purchase_Date;
					textView3.Text = getdate.Store;
					textView4.Text = getdate.Subtotal;
					textView5.Text = getdate.Tax;
					textView6.Text = getdate.TOTAL;
					textView7.Text = getdate.Vendor;
				}
				itemview.Click += (sender, e) =>
				{
					TextView txtPONumber = itemview.FindViewById<TextView>(Resource.Id.txtPO_NumberCV4);
					TextView textview2 = itemview.FindViewById<TextView>(Resource.Id.txtPurchase_DateCV4);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtStoreCV4);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtSubTotalCV4);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtTaxCV4);
					TextView textView6 = itemview.FindViewById<TextView>(Resource.Id.txtTotalCV4);
					TextView textView7 = itemview.FindViewById<TextView>(Resource.Id.txtVendorCV4);
					AlertDialog.Builder dialog = new AlertDialog.Builder(context);
					//AlertDialog alert = dialog.Create();
					//
					//alert.SetMessage(textview2.Text + "\n" + "Store - " + textView3.Text
					//	+ "\n" + "SubTotal - " + textView4.Text + "\n" + "Tax -  " + textView5.Text);
					//alert.Show();
					onclick(getDateModels[viewType]);
				};
			}
			catch (Exception)
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new RecordDateAdapterViewHolder(itemview);
		}

		private void onclick(GetDateModel getDateModel)
		{
			Intent intent = new Intent(context, typeof(PODetailActivity));
			intent.PutExtra("PONumber", getDateModel.PO_Number);
			context.StartActivity(intent);
		}
	}
}