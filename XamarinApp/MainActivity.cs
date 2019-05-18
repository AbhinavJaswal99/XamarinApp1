using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using XamarinApp.Activities;
using Models.ConnectionSt;
using XamarinApp.Adapter;
using Android.Support.V4.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Views;
using XamarinApp.Fragments;
using NewInstance = Android.Support.V4.Widget;
using Android.Content;
using Repository;
using Newtonsoft.Json.Linq;
using Models.Models;
using Felipecsl.GifImageViewLibrary;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace XamarinApp
{
    [Activity(Label ="ConsumeAPI",Theme = "@style/Base.Theme.DesignDemo", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
		Android.App.ProgressDialog progress;
		DrawerLayout drawerLayout;
	    NavigationView navigationView;
		UIPostVendorFragment IPostVendorFragment = new UIPostVendorFragment();
		UIRecordDateFragment UIRecordDate = new UIRecordDateFragment();
		UIStoreFragment UIStore  = new UIStoreFragment();
		UIStoreMinimumFragment UIStoreMinimum = new UIStoreMinimumFragment();
		UIVendorPurchaseFragment UIVendorPurchase = new UIVendorPurchaseFragment();
		UIDetailFragment1.UIDetailFragment IDetailFragment1 = new UIDetailFragment1.UIDetailFragment();
		protected  override void OnCreate(Bundle savedInstanceState)
        {
			PathLink.VendorURI = "http://52.172.37.210:36378/api/InventoryManager/Savevendorpurchaserecord";
			PathLink.StoreURI = "http://52.172.37.210:36378/api/stores/getstores";
			PathLink.VendorPurchaseURI = "http://52.172.37.210:36378/api/InventoryManager/GetVendorPurchaseRequests?from=";
			PathLink.StoreMinimumURI = "http://52.172.37.210:36378/api/inventorymanager/searchinventoryitem?itm=";
			PathLink.DateURI = "http://52.172.37.210:36378/api/purchasemanager/getpos?frmdate=";
			PathLink.UserURI = "http://52.172.37.210:36378/api/employeemanager/validateemployee?ecode=";
			PathLink.PONumberURI = "http://52.172.37.210:36378/api/purchasemanager/getpodetail?po=";


			base.OnCreate(savedInstanceState);
		
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout1);
		
			Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
		    var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
		    drawerLayout.SetDrawerListener(drawerToggle);
		    	drawerToggle.SyncState();
			navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			//	setupDrawerContent(navigationView); //Calling Function 

		
			navigationView.NavigationItemSelected += (sender, e) =>
			{
				e.MenuItem.SetChecked(true);

				switch (e.MenuItem.ItemId)
				{
					case Resource.Id.nav_UIStore:
						ListItemClicked(0);		
						break;
					case Resource.Id.nav_UIPostVendor:
					//	ValidateDialog();
						ListItemClicked(1);
						break;
					case Resource.Id.nav_UIStoreMinimum:
						ListItemClicked(2);
						break;
					case Resource.Id.nav_UIVendorPurchase:
						ListItemClicked(3);
						break;
					case Resource.Id.nav_UIRecordDate:
						ListItemClicked(4);
						break;
					case Resource.Id.nav_UIDetail:
						ListItemClicked(5);
						break;
				}
				drawerLayout.CloseDrawers();
			};

			if(savedInstanceState == null)
			{
				ListItemClicked(0);
			}

		}

		int oldposition = -1;
		private void ListItemClicked(int position)
		  {
			var trans = SupportFragmentManager.BeginTransaction();
			if (position == oldposition)
				return;

			oldposition = position;

			Android.Support.V4.App.Fragment fragment = null;
		   	switch (position)
			{
				case 0:
					ProgressDialog();
					trans.Replace(Resource.Id.content_frame, UIStore ).AddToBackStack(null).Commit();
					//fragment = UIStoreFragment.NewInstance();
					break;
				case 1:
					ProgressDialog();
					ValidateDialog();
					//fragment = UIPostVendorFragment.NewInstance();
				
					break;
				case 2:
					//	fragment = UIStoreMinimumFragment.NewInstance();
					ProgressDialog();
					trans.Replace(Resource.Id.content_frame, UIStoreMinimum).AddToBackStack(null).Commit();
					break;
				case 3:
					//fragment = UIVendorPurchaseFragment.NewInstance();
					ProgressDialog();
					trans.Replace(Resource.Id.content_frame, UIVendorPurchase).AddToBackStack(null).Commit();
					break;
				case 4:
					//	fragment = UIRecordDateFragment.NewInstance();
					ProgressDialog();
					trans.Replace(Resource.Id.content_frame, UIRecordDate).AddToBackStack(null).Commit();
					break;
				case 5:
					//	fragment = UIDetailFragment1.UIDetailFragment.NewInstance();
					ProgressDialog();
					trans.Replace(Resource.Id.content_frame, IDetailFragment1).AddToBackStack(null).Commit();
					break;
			}

			
			
		//SupportFragmentManager.BeginTransaction()
		//	.Replace(Resource.Id.content_frame, fragment).Commit();

		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
					return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		public async void ProgressDialog()
		{
			try
			{
				progress = new ProgressDialog(this);
				progress.Indeterminate = true;
				progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);

				//progress.SetProgressDrawable(Resource.Drawable.loading);
				progress.SetMessage("Loading data....");

				progress.SetCancelable(false);
				progress.Show();
				await Task.Run((() => Foo()));

				progress.Dismiss();

				void Foo()
				{
					for (int i = 0; i < 2; i++)
					{
						Thread.Sleep(500);
					}
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
			
		}
		
		public void ValidateDialog()
		{
			
			Button btnLoad;
			EditText edtemp_code;
		
			try
			{
				View view = LayoutInflater.Inflate(Resource.Layout.DialogPostValidation, null);
				Android.App.AlertDialog dialog = new Android.App.AlertDialog.Builder(this).Create();
				edtemp_code = view.FindViewById<EditText>(Resource.Id.edtEmp_Code);
				edtemp_code = view.FindViewById<EditText>(Resource.Id.edtEmp_Code);
				dialog.SetView(view);
				dialog.SetTitle("Employee Code");
				btnLoad = view.FindViewById<Button>(Resource.Id.btnLoadDialogPost);
				dialog.Show();
				btnLoad.Click += async delegate
				{
					
					ReturnGenericPost returnGenericPost = new ReturnGenericPost();
					string CS = PathLink.UserURI;
					JObject obj = await returnGenericPost.ReturnGeneralPosMeth(CS + edtemp_code.Text.ToUpper(), null);
					GetResult getResult1 = obj.ToObject<GetResult>();
					if (getResult1.Status == 1)
					{

						Bundle mybundle = new Bundle();
						string emp_code = edtemp_code.Text.ToUpper();
						//	Intent intent = new Intent(this, typeof(UIPostVendorFragment));
						//intent.PutExtra("empcode", emp_code);
						mybundle.PutString("employee", emp_code);

						var fragmentTransaction = FragmentManager.BeginTransaction();
						UIPostVendorFragment uIPostVendor = new UIPostVendorFragment();
						uIPostVendor.Arguments = mybundle;
						SupportFragmentManager.BeginTransaction()
				       .Replace(Resource.Id.content_frame, uIPostVendor).AddToBackStack(null).Commit();
						dialog.Dismiss();

					


					}
				};
				dialog.Show();

			}
			catch (System.Exception ex)
			{

				throw ex;
			}
			
		}
		

	}
}