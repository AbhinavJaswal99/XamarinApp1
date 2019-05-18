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

namespace XamarinApp.Adapter
{
	public class StoreMinAdapterViewHolder : RecyclerView.ViewHolder
	{
	
	    public View itemview { get; set; }
		public TextView Heading1 { get; set; }
		public TextView Heading2 { get; set; }
		public TextView Heading3 { get; set; }
		public TextView Heading4 { get; set; }
		public TextView Heading5 { get; set; }


		public StoreMinAdapterViewHolder(View itemView) : base(itemView)
		{
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.txtStoreCV3);
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.txtCodeCV3);
			Heading3 = itemView.FindViewById<TextView>(Resource.Id.txtQuantityCV3);
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.txtColorCV3);
			Heading5 = itemView.FindViewById<TextView>(Resource.Id.txtCategoryCV3);

			this.itemview = itemview;
		}

	}
	public	class StoreMinAdapter : RecyclerView.Adapter
	{ 
		Context context;

		public List<StoreMinModel> lstStoreMinModel = new List<StoreMinModel>();


		public StoreMinAdapter(List<StoreMinModel> storeMinModels)
		{
			this.lstStoreMinModel = storeMinModels;
		}
		public StoreMinAdapter(Context context)
		{
			this.context = context;
		}



		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			StoreMinAdapterViewHolder adapterViewHolder = holder as StoreMinAdapterViewHolder;
			adapterViewHolder.Heading1.Text = lstStoreMinModel[position].STORE;
			adapterViewHolder.Heading2.Text = lstStoreMinModel[position].CODE;
			adapterViewHolder.Heading3.Text = lstStoreMinModel[position].QTY;
			adapterViewHolder.Heading4.Text = lstStoreMinModel[position].COLOR;
			adapterViewHolder.Heading5.Text = lstStoreMinModel[position].CATEGORY;



		}
		public override int ItemCount
		{
			get { return lstStoreMinModel.Count; }
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Cardview3, parent, false);

			context = parent.Context;
			try
			{
				foreach (var store1 in lstStoreMinModel)
				{
					TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txtStoreCV3);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txtCodeCV3);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtQuantityCV3);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtColorCV3);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtCategoryCV3);
					textView1.Text = store1.STORE;
					textView2.Text = store1.CODE;
					textView3.Text = store1.QTY;
					textView4.Text = store1.COLOR;
					textView5.Text = store1.CATEGORY;

				}


				itemview.Click += (sender, e) =>
				{
					TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.txtStoreCV3);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.txtCodeCV3);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.txtQuantityCV3);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.txtColorCV3);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.txtCategoryCV3);
					AlertDialog.Builder dialog = new AlertDialog.Builder(context);
					AlertDialog alert = dialog.Create();

					alert.SetMessage(textView2.Text + "\n" + "QUANTITY - " + textView3.Text
						+ "\n" + "COLOR - " + textView4.Text + "\n" + "CATEGORY -  " + textView5.Text);



					alert.Show();
				};
			}
			catch (Exception)
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new StoreMinAdapterViewHolder(itemview);

		}

	}
}