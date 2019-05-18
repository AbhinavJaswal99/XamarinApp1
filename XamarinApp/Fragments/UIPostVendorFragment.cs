using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Models.Models;
using Repository;
using Newtonsoft.Json;
using System.Net.Http;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;

namespace XamarinApp.Fragments
{
	public class UIPostVendorFragment : Fragment
	{
		TextView editempcode;
		private EditText  Store, Code, Quantity, VendorName, VendorContact, VendorAddress, VendorCost,
				 SellingCost, CustomerName, CustomerContact;
		private Button btnSubmit;
		View view;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


		}

		public static UIPostVendorFragment NewInstance()
		{
			var frag1 = new UIPostVendorFragment { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIVendorModel, container, false);
				//	Emp_Code = view.FindViewById<EditText>(Resource.Id.txtempcode);
				editempcode = view.FindViewById<TextView>(Resource.Id.txt_empcodeUIVendor);
				Store = view.FindViewById<EditText>(Resource.Id.txtStore);
				Code = view.FindViewById<EditText>(Resource.Id.txtCode);
				Quantity = view.FindViewById<EditText>(Resource.Id.txtVendorName);
				VendorName = view.FindViewById<EditText>(Resource.Id.txtVendorName);
				VendorContact = view.FindViewById<EditText>(Resource.Id.txtVendorContact);
				VendorAddress = view.FindViewById<EditText>(Resource.Id.txtVendorAddress);
				VendorCost = view.FindViewById<EditText>(Resource.Id.txtVendorCost);
				SellingCost = view.FindViewById<EditText>(Resource.Id.txtSellingCost);
				CustomerName = view.FindViewById<EditText>(Resource.Id.txtCustomerName);
				CustomerContact = view.FindViewById<EditText>(Resource.Id.txtCustomerContact);
				btnSubmit = view.FindViewById<Button>(Resource.Id.btnSubmit);

				string MyEmployeeCode = Arguments.GetString("employee");
				editempcode.Text = MyEmployeeCode;
				btnSubmit.Click += BtnSubmit_Click;

				return view;
			}
			catch (Exception)
			{

				throw;
			}
			

		}

		private async void BtnSubmit_Click(object sender, EventArgs e)
		{
			try
			{
			   // Emp_Code = view.FindViewById<EditText>(Resource.Id.txtempcode);
				Store = view.FindViewById<EditText>(Resource.Id.txtStore);
				Code = view.FindViewById<EditText>(Resource.Id.txtCode);
				Quantity = view.FindViewById<EditText>(Resource.Id.txtQuantity);
				VendorName = view.FindViewById<EditText>(Resource.Id.txtVendorName);
				VendorContact = view.FindViewById<EditText>(Resource.Id.txtVendorContact);
				VendorAddress = view.FindViewById<EditText>(Resource.Id.txtVendorAddress);
				VendorCost = view.FindViewById<EditText>(Resource.Id.txtVendorCost);
				SellingCost = view.FindViewById<EditText>(Resource.Id.txtSellingCost);
				CustomerName = view.FindViewById<EditText>(Resource.Id.txtCustomerName);
				CustomerContact = view.FindViewById<EditText>(Resource.Id.txtCustomerContact);

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
			
				
					if (returnValidation.DecimalValidation(Quantity.Text) && returnValidation.DecimalValidation(VendorCost.Text) && returnValidation.DecimalValidation(SellingCost.Text))
					{
						string Json = JsonConvert.SerializeObject(vendorModel);
						HttpContent stringContent = new StringContent(Json, encoding: Encoding.UTF8, mediaType: "application/json");
						ReturnGenericPost returnGenericPost = new ReturnGenericPost();
						string CS = PathLink.VendorURI;

						JObject obj = await returnGenericPost.ReturnGeneralPosMeth(CS, stringContent);
						GetResult getResult1 = obj.ToObject<GetResult>();
						if (getResult1.Status == 1)
						{
							View view = LayoutInflater.Inflate(Resource.Layout.UIVendorModel, null);
							Android.Support.V7.App.AlertDialog alert = new Android.Support.V7.App.AlertDialog.Builder(Context).Create();

							alert.SetTitle("Done");
							alert.SetMessage("Data is Posted");
							//	alert.Dismiss();
							//	Toast.MakeText(Context, "Alert Dialog dismissed!!!", ToastLength.Short).Show();
							alert.Show();
						}
					}
					else
					{
						Android.Support.V7.App.AlertDialog alert = new Android.Support.V7.App.AlertDialog.Builder(Context).Create();
						alert.SetTitle("What the Hell !!!!");
						alert.SetMessage("Please add genuine value in Quantity, VendorCost and Selling Textboxes");
						//alert.Dismiss();
						alert.Show();
					}
				}
			catch (Exception ex)
			{
				throw ex;
			}
		}

			
		}
		
	}