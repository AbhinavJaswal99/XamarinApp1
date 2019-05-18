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
	public class POModelAdapterViewHolder : RecyclerView.ViewHolder
	{
		public View itemview { get; set; }
		public TextView Heading1 { get; set; }
		public TextView Heading2 { get; set; }
		public TextView Heading3 { get; set; }
		public TextView Heading4 { get; set; }
		public TextView Heading5 { get; set; }
		public TextView Heading6 { get; set; }
		public TextView Heading7 { get; set; }
		public TextView Heading8 { get; set; }
		public TextView Heading9 { get; set; }
		public TextView Heading10 { get; set; }

		public POModelAdapterViewHolder(View itemView) : base(itemView)
		{
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.txt_ManCodeCV8);
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.txt_DESCRCV8);
			Heading3 = itemView.FindViewById<TextView>(Resource.Id.txt_Sell_PriceCV8);
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.txt_CostCV8);
			Heading5 = itemView.FindViewById<TextView>(Resource.Id.txt_QUANTITYCV8);
			Heading6 = itemView.FindViewById<TextView>(Resource.Id.txt_Total_CostCV8);
			Heading7 = itemView.FindViewById<TextView>(Resource.Id.txt_Qty_RecievedCV8);
			Heading8 = itemView.FindViewById<TextView>(Resource.Id.txt_StatusCV8);
			Heading9 = itemView.FindViewById<TextView>(Resource.Id.txt_ColorCV8);
			Heading10 = itemView.FindViewById<TextView>(Resource.Id.txt_DateRecCV8);

			this.itemview = itemview;
		}
	}
    public	class POModelAdapter : RecyclerView.Adapter
	{
		Context context;

		public List<POModel> getPOModels = new List<POModel>();

		public override int ItemCount
		{
			get { return getPOModels.Count; }
		}

		public POModelAdapter(List<POModel> pOModels)
		{
			this.getPOModels = pOModels;
		}

		public POModelAdapter(Context context)
		{
			this.context = context;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			POModelAdapterViewHolder adapterViewHolder = holder as POModelAdapterViewHolder;
			adapterViewHolder.Heading1.Text = getPOModels[position].MAN_CODE;
			adapterViewHolder.Heading2.Text = getPOModels[position].DESCR;
			adapterViewHolder.Heading3.Text = getPOModels[position].SELL_PRICE;
			adapterViewHolder.Heading4.Text = getPOModels[position].Cost;
			adapterViewHolder.Heading5.Text = getPOModels[position].Quantity;
			adapterViewHolder.Heading6.Text = getPOModels[position].Total_Cost;
			adapterViewHolder.Heading7.Text = getPOModels[position].Qty_Recieved;
			adapterViewHolder.Heading8.Text = getPOModels[position].Status;
			adapterViewHolder.Heading9.Text = getPOModels[position].COLOR;
			adapterViewHolder.Heading10.Text = getPOModels[position].DATE_REC;

		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PODialogCV8, parent, false);

			context = parent.Context;
			TextView txtManCode, txtDesc, txtSellPrice, txtCost, txtQuantity, txtTotalCost, txtQtyRecieved, txtStatus,
			txtColor, txtDateRec;
			try
			{
				foreach(var itm in getPOModels)
				{
					txtManCode = itemview.FindViewById<TextView>(Resource.Id.txt_ManCodeCV8);
					txtDesc = itemview.FindViewById<TextView>(Resource.Id.txt_DESCRCV8);
					txtSellPrice = itemview.FindViewById<TextView>(Resource.Id.txt_Sell_PriceCV8);
					txtCost = itemview.FindViewById<TextView>(Resource.Id.txt_CostCV8);
					txtQuantity = itemview.FindViewById<TextView>(Resource.Id.txt_QUANTITYCV8);
					txtTotalCost = itemview.FindViewById<TextView>(Resource.Id.txt_Total_CostCV8);
					txtQtyRecieved = itemview.FindViewById<TextView>(Resource.Id.txt_Qty_RecievedCV8);
					txtStatus = itemview.FindViewById<TextView>(Resource.Id.txt_StatusCV8);
					txtColor = itemview.FindViewById<TextView>(Resource.Id.txt_ColorCV8);
					txtDateRec = itemview.FindViewById<TextView>(Resource.Id.txt_DateRecCV8);
					txtManCode.Text = itm.MAN_CODE;
					txtDesc.Text = itm.DESCR;
					txtSellPrice.Text = itm.SELL_PRICE;
					txtCost.Text = itm.Cost;
					txtQuantity.Text = itm.Quantity;
					txtTotalCost.Text = itm.Total_Cost;
					txtQtyRecieved.Text = itm.Qty_Recieved;
					txtStatus.Text = itm.Status;
					txtColor.Text = itm.COLOR;
					txtDateRec.Text = itm.DATE_REC;
				}
			}
			catch (Exception)
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new POModelAdapterViewHolder(itemview);
		}
	}
}