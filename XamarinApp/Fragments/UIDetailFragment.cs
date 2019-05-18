using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using XamarinApp.Adapter;
using Fragment = Android.Support.V4.App.Fragment;
using System;
using Repository;
using Models.ConnectionSt;
using Newtonsoft.Json.Linq;
using Models.ViewModels;
using Android.Support.V4.App;
using fragmentManager = Android.App;
using Android.App;
using System.Threading;

namespace XamarinApp.Fragments
{
	public class UIDetailFragment1 : Fragment
	{

		
		public override  void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		

		public class UIDetailFragment : Android.Support.V4.App.DialogFragment
		{

			public static UIDetailFragment NewInstance()
			{
				var frag1 = new UIDetailFragment { Arguments = new Bundle() };
				return frag1;
			}

			View view;
			Button btnUIDetail;
			RecyclerView mrecyclerview;
			LinearLayoutManager mlayoutmanager;
			DetailAdapter detailadapter;
			Android.App.ProgressDialog progress;
			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				try
				{
					view = inflater.Inflate(Resource.Layout.UIDetail, container, false);
					btnUIDetail = view.FindViewById<Button>(Resource.Id.btnUIDetail);
					mrecyclerview = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewUIDeTL);
					mlayoutmanager = new LinearLayoutManager(this.Context);
					mrecyclerview.SetLayoutManager(mlayoutmanager);
					btnUIDetail.Click += BtnUIDetail_Click;
				//	mrecyclerview.Click += Mrecyclerview_Click;
					return view;
				}
				catch (Exception ex)
				{

					throw ex;
				}
			}

		//private void Mrecyclerview_Click(object sender, EventArgs e)
		//{
		//}

			private async void BtnUIDetail_Click(object sender, EventArgs e)
			{
				try
				{
					ReturnGenericGet returnGenericGet = new ReturnGenericGet();
					string CS = PathLink.StoreURI;
					JObject obj = await returnGenericGet.GetReturnGeneric(CS);
					vMStore vMStore = obj.ToObject<vMStore>();
					detailadapter = new DetailAdapter(vMStore.Detail);
					if (vMStore.Status == 1)
					{
						mrecyclerview.SetAdapter(detailadapter);
					}




				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			public async void ProgressDialog()
			{
				try
				{
					progress = new ProgressDialog(Context)
					{
						Indeterminate = true
					};
					progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);

					//progress.SetProgressDrawable(Resource.Drawable.loading);
					progress.SetMessage("Loading data....");

					progress.SetCancelable(false);
					progress.Show();
					await System.Threading.Tasks.Task.Run((() => Foo()));

					progress.Dismiss();

					void Foo()
					{
						for (int i = 0; i < 2; i++)
						{
							Thread.Sleep(500);
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		
	}
}