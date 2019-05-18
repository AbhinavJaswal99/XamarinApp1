using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using XamarinApp.Adapter;

namespace XamarinApp
{
	[Activity(Label = "PODetailActivity")]
	public class PODetailActivity : Activity
	{
		POModelAdapter POModelAdapter;
		TextView txtPONumber;
		TextView txtManCode, txtDesc, txtSellPrice, txtCost, txtQuantity, txtTotalCost, txtQtyRecieved, txtStatus,
			txtColor, txtDateRec;
		RecyclerView recyclerview;
		RecyclerView.LayoutManager mLayoutManager;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CardView4);
			// View view = LayoutInflater.Inflate(Resource.Layout.PODialogCV8, null);
		    txtPONumber = FindViewById<TextView>(Resource.Id.txtPO_NumberCV4);
			txtPONumber.Text = Intent.GetStringExtra("PONumber");
			//   SetContentView(Resource.Layout.PODialogCV8);
			//   txtManCode = FindViewById<TextView>(Resource.Id.txt_ManCodeCV8);
			//   txtDesc = FindViewById<TextView>(Resource.Id.txt_DESCRCV8);
			//   txtSellPrice = FindViewById<TextView>(Resource.Id.txt_Sell_PriceCV8);
			//   txtCost = FindViewById<TextView>(Resource.Id.txt_CostCV8);
			//   txtQuantity = FindViewById<TextView>(Resource.Id.txt_QUANTITYCV8);
			//   txtTotalCost = FindViewById<TextView>(Resource.Id.txt_Total_CostCV8);
			//   txtQtyRecieved = FindViewById<TextView>(Resource.Id.txt_Qty_RecievedCV8);
			//   txtStatus = FindViewById<TextView>(Resource.Id.txt_StatusCV8);
			//   txtColor = FindViewById<TextView>(Resource.Id.txt_ColorCV8);
			//   txtDateRec = FindViewById<TextView>(Resource.Id.txt_DateRecCV8);
			SetContentView(Resource.Layout.PODetailFragment);
			recyclerview = FindViewById<RecyclerView>(Resource.Id.PO_recyclerView1);
			mLayoutManager = new LinearLayoutManager(this);
			recyclerview.SetLayoutManager(mLayoutManager);

			LoadSeries();
			

		}
		public async Task LoadSeries()
		{
			ReturnGenericGet returnGenericGet = new ReturnGenericGet();
			string CS = PathLink.PONumberURI;
			JObject obj = await returnGenericGet.GetReturnGeneric(CS + txtPONumber.Text);
			vMPOModel vMPOModel = obj.ToObject<vMPOModel>();
			POModelAdapter = new POModelAdapter(vMPOModel.Detail);
			if(vMPOModel.Status == 1)
			{
				recyclerview.SetAdapter(POModelAdapter);

			//foreach(var itm in vMPOModel.Detail)
			//{
			//	txtManCode = FindViewById<TextView>(Resource.Id.txt_ManCodeCV8);
			//	txtDesc = FindViewById<TextView>(Resource.Id.txt_DESCRCV8);
			//	txtSellPrice = FindViewById<TextView>(Resource.Id.txt_Sell_PriceCV8);
			//	txtCost = FindViewById<TextView>(Resource.Id.txt_CostCV8);
			//	txtQuantity = FindViewById<TextView>(Resource.Id.txt_QUANTITYCV8);
			//	txtTotalCost = FindViewById<TextView>(Resource.Id.txt_Total_CostCV8);
			//	txtQtyRecieved = FindViewById<TextView>(Resource.Id.txt_Qty_RecievedCV8);
			//	txtStatus = FindViewById<TextView>(Resource.Id.txt_StatusCV8);
			//	txtColor = FindViewById<TextView>(Resource.Id.txt_ColorCV8);
			//	txtDateRec = FindViewById<TextView>(Resource.Id.txt_DateRecCV8);
			//	txtManCode.Text = itm.MAN_CODE;
			//	txtDesc.Text = itm.DESCR;
			//	txtSellPrice.Text = itm.SELL_PRICE;
			//	txtCost.Text = itm.Cost;
			//	txtQuantity.Text = itm.Quantity;
			//	txtTotalCost.Text = itm.Total_Cost;
			//	txtQtyRecieved.Text = itm.Qty_Recieved;
			//	txtStatus.Text = itm.Status;
			//	txtColor.Text = itm.COLOR;
			//	txtDateRec.Text = itm.DATE_REC;
			//}
			}
		}

	}
}