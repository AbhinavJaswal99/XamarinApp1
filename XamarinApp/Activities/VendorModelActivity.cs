using System;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.OS;
using Android.Widget;
using Models.ConnectionSt;
using Models.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository;

namespace XamarinApp.Activities
{
	[Activity(Label = "VendorModelActivity")]
	public class VendorModelActivity : Activity
	{
		private EditText Emp_Code, Store, Code, Quantity, VendorName, VendorContact, VendorAddress, VendorCost,
				 SellingCost, CustomerName, CustomerContact;
		private Button Submit;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.UIVendorModel);

	    //    Emp_Code = FindViewById<EditText>(Resource.Id.txtempcode);
	        Store = FindViewById<EditText>(Resource.Id.txtStore);
	        Code = FindViewById<EditText>(Resource.Id.txtCode);
	        Quantity = FindViewById<EditText>(Resource.Id.txtVendorName);
	        VendorName = FindViewById<EditText>(Resource.Id.txtVendorName);
	        VendorContact = FindViewById<EditText>(Resource.Id.txtVendorContact);
	        VendorAddress = FindViewById<EditText>(Resource.Id.txtVendorAddress);
	        VendorCost = FindViewById<EditText>(Resource.Id.txtVendorCost);
	        SellingCost = FindViewById<EditText>(Resource.Id.txtSellingCost);
	        CustomerName = FindViewById<EditText>(Resource.Id.txtCustomerName);
	        CustomerContact = FindViewById<EditText>(Resource.Id.txtCustomerContact);
	        Submit = FindViewById<Button>(Resource.Id.btnSubmit);
	        Submit.Click += Submit_Click;
		
		}

		private async void Submit_Click(object sender, EventArgs e)
		{
			//Emp_Code = FindViewById<EditText>(Resource.Id.txtempcode);
			Store = FindViewById<EditText>(Resource.Id.txtStore);
			Code = FindViewById<EditText>(Resource.Id.txtCode);
			Quantity = FindViewById<EditText>(Resource.Id.txtQuantity);
			VendorName = FindViewById<EditText>(Resource.Id.txtVendorName);
			VendorContact = FindViewById<EditText>(Resource.Id.txtVendorContact);
			VendorAddress = FindViewById<EditText>(Resource.Id.txtVendorAddress);
			VendorCost = FindViewById<EditText>(Resource.Id.txtVendorCost);
			SellingCost = FindViewById<EditText>(Resource.Id.txtSellingCost);
			CustomerName = FindViewById<EditText>(Resource.Id.txtCustomerName);
			CustomerContact = FindViewById<EditText>(Resource.Id.txtCustomerContact);

			VendorModel vendorModel = new VendorModel()
			{
				//emp_code = Emp_Code.Text,
				store = Store.Text,
				code = Code.Text,
				quantity = Quantity.Text,
				vendorname = VendorName.Text,
				vendorcontact = VendorContact.Text,
				vendoraddress = VendorAddress.Text,
				vendorcost = VendorCost.Text,
				sellingcost = SellingCost.Text,
				customername = CustomerName.Text,
				customercontact = CustomerContact.Text,
			};
			ReturnValidation returnValidation = new ReturnValidation();
			if(returnValidation.DecimalValidation(Quantity.Text) && returnValidation.DecimalValidation(VendorCost.Text) && returnValidation.DecimalValidation(SellingCost.Text))
			{
				string Json = JsonConvert.SerializeObject(vendorModel);
				HttpContent stringContent = new StringContent(Json, encoding: Encoding.UTF8, mediaType: "application/json");
				ReturnGenericPost returnGenericPost = new ReturnGenericPost();
				string CS = PathLink.VendorURI;

				JObject obj = await returnGenericPost.ReturnGeneralPosMeth(CS, stringContent);
				GetResult getResult1 = obj.ToObject<GetResult>();
				if(getResult1.Status == 1)
				{
				Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
				AlertDialog alert = dialog.Create();
				alert.SetTitle("Done");
				alert.SetMessage("Data is Posted");
				alert.SetButton("OK", (c, ev) =>
				{
					// Ok button click task  
				});
				alert.Show();
			}	
			}
			else
			{
				Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
				AlertDialog alert = dialog.Create();
				alert.SetTitle("Validation Error");
				alert.SetMessage("Add genuine values in Quantity or VendorCost or SellingCost Textboxes!!!!");

				alert.SetButton("OK", (c, ev) =>
				{
					// Ok button click task  
				});
				alert.Show();

			}
		}
	}
}
					
			
			
	//		}
	//}
	//}
