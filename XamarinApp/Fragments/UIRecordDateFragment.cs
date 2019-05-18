using Android.OS;
using Android.Views;
using Android.Widget;
using  Android.Support.V4.App;
using System;
using Android.Support.V7.Widget;
using Repository;
using Android.App;
using Android.Content;
using Fragment = Android.Support.V4.App.Fragment;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;
using Models.ViewModels;
using XamarinApp.Adapter;
using static Android.Support.V7.Widget.RecyclerView;

namespace XamarinApp.Fragments
{
	public class UIRecordDateFragment : Fragment
	{

		View view;
		EditText edtxtfromdate, edtxttodate;
		Button btnLoadStore;
		RecyclerView UIRDrecyclerview;
		LinearLayoutManager mlayoutmanager;
		RecordDateAdapter recordDateAdapter;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public static UIRecordDateFragment NewInstance()
		{
			var frag1 = new UIRecordDateFragment { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIRecordDate, container, false);
				edtxtfromdate = view.FindViewById<EditText>(Resource.Id.edtxtfromUIRD);
				edtxttodate = view.FindViewById<EditText>(Resource.Id.edtxttoUIRD);
				btnLoadStore = view.FindViewById<Button>(Resource.Id.btnLoadUIRD);
				UIRDrecyclerview = view.FindViewById<RecyclerView>(Resource.Id.RecyclerViewUIRD);
				mlayoutmanager = new LinearLayoutManager(this.Context);
				UIRDrecyclerview.SetLayoutManager(mlayoutmanager);
				btnLoadStore.Click += BtnLoadStore_Click;

				edtxtfromdate.Click += (sender, e) =>
				{
					DateTime today = DateTime.Today;
					DatePickerDialog dialog = new DatePickerDialog(Context, OnDateSet, today.Year - 1, today.Month - 1, today.Day);
					dialog.DatePicker.MinDate = today.Millisecond;
					dialog.Show();
				};
				void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
				{
					edtxtfromdate.Text = e.Date.ToString("yyyy-MM-dd");

				}

				edtxttodate.Click += (sender, e) =>
				{
					DateTime today = DateTime.Today;
					DatePickerDialog dialog = new DatePickerDialog(Context, OnDateSet1, today.Year , today.Month - 1, today.Day);
					dialog.DatePicker.MinDate = today.Millisecond;
					dialog.Show();
				};

				void OnDateSet1(object sender, DatePickerDialog.DateSetEventArgs e)
				{
					edtxttodate.Text = e.Date.ToString("yyyy-MM-dd");

				}




				return view;

			}
			catch (Exception ex)
			{
				
				throw ex;
			}
		}

		
		private async void BtnLoadStore_Click(object sender, EventArgs e)
		{
			try
			{
				ReturnGenericGet returnGenericGet = new ReturnGenericGet();
				string CS = PathLink.DateURI;
				JObject obj = await returnGenericGet.GetReturnGeneric(CS + edtxtfromdate.Text + "&todate=" + edtxttodate.Text);
				vMGetDateModel vMGetDateModel = obj.ToObject<vMGetDateModel>();
				 recordDateAdapter = new RecordDateAdapter(vMGetDateModel.Detail);
				
				if(vMGetDateModel.Status == 1)
				{
					UIRDrecyclerview.SetAdapter(recordDateAdapter);
				}

			}
			catch (Exception ex)
			{
				Toast.MakeText(Context,"Enter values", ToastLength.Long).Show();
				throw ex;
			}
		}
	}
}