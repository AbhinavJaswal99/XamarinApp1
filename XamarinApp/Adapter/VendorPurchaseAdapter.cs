using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Models.Models;

namespace XamarinApp.Adapter
{
    public	class VendorPurchaseAdapterViewHolder : RecyclerView.ViewHolder
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
		public TextView Heading11 { get; set; }
		public TextView Heading12 { get; set; }
		public TextView Heading13 { get; set; }
		public TextView Heading14 { get; set; }
		public TextView Heading15 { get; set; }
		public TextView Heading16 { get; set; }

	
		public VendorPurchaseAdapterViewHolder(View itemView) : base(itemView)
		{
			Heading1 = itemView.FindViewById<TextView>(Resource.Id.CV2txtCost);					
			Heading2 = itemView.FindViewById<TextView>(Resource.Id.CV2txtSelling_Cost);			
			Heading3 = itemView.FindViewById<TextView>(Resource.Id.CV2txtVendor_name);			
			Heading4 = itemView.FindViewById<TextView>(Resource.Id.CV2txtVendor_Contact);		
			Heading5 = itemView.FindViewById<TextView>(Resource.Id.CV2txtCustomer_Name);		
            Heading6  = itemView.FindViewById<TextView>(Resource.Id.CV2txtCustomer_Contact);	
            Heading7  = itemView.FindViewById<TextView>(Resource.Id.CV2txtRequest_Id);			
            Heading8  = itemView.FindViewById<TextView>(Resource.Id.CV2txtStore);				
            Heading9  = itemView.FindViewById<TextView>(Resource.Id.CV2txtCode);				
            Heading10 = itemView.FindViewById<TextView>(Resource.Id.CV2txtRequestedBy);			
            Heading11 = itemView.FindViewById<TextView>(Resource.Id.CV2txtStatus);				
            Heading12 = itemView.FindViewById<TextView>(Resource.Id.CV2txtRequested_Qty);		
            Heading13 = itemView.FindViewById<TextView>(Resource.Id.CV2txtApproved_Qty);		
            Heading14 = itemView.FindViewById<TextView>(Resource.Id.CV2txtRequestedOn);			
            Heading15 = itemView.FindViewById<TextView>(Resource.Id.CV2txtApproved_by);			
            Heading16 = itemView.FindViewById<TextView>(Resource.Id.CV2txtApproved_on);


			this.itemview = itemview;
		}
		

		
	}
	public class VendorPurchaseAdapter : RecyclerView.Adapter
	{
		Context context;

		public List<VendorPurchaseModel> lstVendorPurchaseModel = new List<VendorPurchaseModel>();


		public VendorPurchaseAdapter(List<VendorPurchaseModel> vendorPurchaseModels)
		{
			this.lstVendorPurchaseModel = vendorPurchaseModels;
		}
		public VendorPurchaseAdapter(Context context)
		{
			this.context = context;
		}


		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{

			VendorPurchaseAdapterViewHolder adapterViewHolder = holder as VendorPurchaseAdapterViewHolder;
			adapterViewHolder.Heading1.Text = lstVendorPurchaseModel[position].Cost;                
			adapterViewHolder.Heading2.Text = lstVendorPurchaseModel[position].SELLING_COST;
			adapterViewHolder.Heading3.Text = lstVendorPurchaseModel[position].VENDOR_NAME;
			adapterViewHolder.Heading4.Text = lstVendorPurchaseModel[position].VENDOR_CONTACT;
			adapterViewHolder.Heading5.Text = lstVendorPurchaseModel[position].CUSTOMER_NAME;
			adapterViewHolder.Heading6.Text = lstVendorPurchaseModel[position].CUSTOMER_CONTACT;
			adapterViewHolder.Heading7.Text = lstVendorPurchaseModel[position].Request_ID;
			adapterViewHolder.Heading8.Text = lstVendorPurchaseModel[position].STORE;
			adapterViewHolder.Heading9.Text = lstVendorPurchaseModel[position].CODE;
			adapterViewHolder.Heading10.Text = lstVendorPurchaseModel[position].Requested_By;
			adapterViewHolder.Heading11.Text = lstVendorPurchaseModel[position].Status;
			adapterViewHolder.Heading12.Text = lstVendorPurchaseModel[position].Requested_Qty;
			adapterViewHolder.Heading13.Text = lstVendorPurchaseModel[position].Approved_QTY;
			adapterViewHolder.Heading14.Text = lstVendorPurchaseModel[position].REQUESTED_ON;
			adapterViewHolder.Heading15.Text = lstVendorPurchaseModel[position].Requested_By;
			adapterViewHolder.Heading16.Text = lstVendorPurchaseModel[position].APPROVED_ON;



		}

		public override int ItemCount
		{
			get { return lstVendorPurchaseModel.Count; }
		}


		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView2, parent, false);

			context = parent.Context;
			try
			{
				foreach (var VendorPurchaseModel1 in lstVendorPurchaseModel)
				{
					TextView textView1 = itemview.FindViewById<TextView>(Resource.Id.CV2txtCost);
					TextView textView2 = itemview.FindViewById<TextView>(Resource.Id.CV2txtSelling_Cost);
					TextView textView3 = itemview.FindViewById<TextView>(Resource.Id.CV2txtVendor_name);
					TextView textView4 = itemview.FindViewById<TextView>(Resource.Id.CV2txtVendor_Contact);
					TextView textView5 = itemview.FindViewById<TextView>(Resource.Id.CV2txtCustomer_Name);
					TextView textView6 = itemview.FindViewById<TextView>(Resource.Id.CV2txtCustomer_Contact);
					TextView textView7 = itemview.FindViewById<TextView>(Resource.Id.CV2txtRequest_Id);
					TextView textView8 = itemview.FindViewById<TextView>(Resource.Id.CV2txtStore);
					TextView textView9 = itemview.FindViewById<TextView>(Resource.Id.CV2txtCode);
					TextView textView10 = itemview.FindViewById<TextView>(Resource.Id.CV2txtRequestedBy);
					TextView textView11 = itemview.FindViewById<TextView>(Resource.Id.CV2txtStatus);
					TextView textView12 = itemview.FindViewById<TextView>(Resource.Id.CV2txtRequested_Qty);
					TextView textView13 = itemview.FindViewById<TextView>(Resource.Id.CV2txtApproved_Qty);
					TextView textView14 = itemview.FindViewById<TextView>(Resource.Id.CV2txtRequestedOn);
					TextView textView15 = itemview.FindViewById<TextView>(Resource.Id.CV2txtApproved_by);
					TextView textView16 = itemview.FindViewById<TextView>(Resource.Id.CV2txtApproved_on);


					textView1.Text = VendorPurchaseModel1.Cost;
					textView2.Text = VendorPurchaseModel1.SELLING_COST;
					textView3.Text = VendorPurchaseModel1.VENDOR_NAME;
					textView4.Text = VendorPurchaseModel1.VENDOR_CONTACT;
					textView5.Text = VendorPurchaseModel1.CUSTOMER_NAME;
					textView6.Text = VendorPurchaseModel1.CUSTOMER_CONTACT;
					textView7.Text = VendorPurchaseModel1.Request_ID;
					textView8.Text = VendorPurchaseModel1.STORE;
					textView9.Text = VendorPurchaseModel1.CODE;
					textView1.Text = VendorPurchaseModel1.Requested_By;
					textView11.Text = VendorPurchaseModel1.Status;
					textView12.Text = VendorPurchaseModel1.Requested_Qty;
					textView13.Text = VendorPurchaseModel1.Approved_QTY;
					textView14.Text = VendorPurchaseModel1.REQUESTED_ON;
					textView15.Text = VendorPurchaseModel1.Requested_By;
					textView16.Text = VendorPurchaseModel1.APPROVED_ON;
				}

				itemview.Click += (sender, e) =>
				{
					onclick(lstVendorPurchaseModel[viewType]);
				};

			}
			
			catch (Exception)
			{
				Toast.MakeText(this.context, "No Data Found !", ToastLength.Long).Show();
				throw;
			}
			return new VendorPurchaseAdapterViewHolder(itemview);

		}

		private void onclick(VendorPurchaseModel vendorPurchaseModel)
		{

			Intent intent = new Intent(context, typeof(VendorPurchaseActivity));
		  
		   intent.PutExtra("Store", vendorPurchaseModel.STORE);
		   intent.PutExtra("Cost", vendorPurchaseModel.Cost);
		   intent.PutExtra("VendorName", vendorPurchaseModel.VENDOR_NAME);
		   intent.PutExtra("CustomerName", vendorPurchaseModel.CUSTOMER_NAME);
		   intent.PutExtra("VendorContact", vendorPurchaseModel.VENDOR_CONTACT);
		   intent.PutExtra("SellingPrice", vendorPurchaseModel.SELLING_COST);
		   intent.PutExtra("CustomerContact", vendorPurchaseModel.CUSTOMER_CONTACT);
		   intent.PutExtra("Quantity", vendorPurchaseModel.Requested_Qty);
		   intent.PutExtra("RequestBy", vendorPurchaseModel.Requested_By);
		   intent.PutExtra("Status", vendorPurchaseModel.Status);
			context.StartActivity(intent);
		}
	}
}