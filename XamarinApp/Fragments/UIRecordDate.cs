﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinApp.Fragments
{
	public class UIRecordDate : Fragment
	{
		View view;
		Button btnLoadAlStore;
		EditText edtxtfromdate, edtxttodate;
		RecyclerView mrecyclerview;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			try
			{
				view = inflater.Inflate(Resource.Layout.UIRecordDate, container, false);
				return view;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}