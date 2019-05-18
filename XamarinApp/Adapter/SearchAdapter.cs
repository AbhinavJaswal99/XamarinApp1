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

namespace XamarinApp.Adapter
{
	class SearchAdapter : RecyclerView.Adapter, IFilterable
	{
		private List<string> galaxies;
		private readonly List<string> currentList;

		public override int ItemCount { get { return galaxies.Count;  } }

		public void setGalaxies ( List<string> filteredGalaxies)
		{
			this.galaxies = filteredGalaxies;
		}

		public Filter Filter => FilterHelper.newInstance(currentList, this);

		public SearchAdapter(List<string> galaxies)
		{
			this.galaxies = galaxies;
			this.currentList = galaxies;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyViewHolder h = holder as MyViewHolder;
			if(h   != null)
			{
				h.Nametxt.Text = galaxies[position];
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cardview1, parent, false);
			MyViewHolder holder = new MyViewHolder(v);
			return holder;
		}
		internal class MyViewHolder : RecyclerView.ViewHolder
		{
			public TextView Nametxt;
			public MyViewHolder(View itemView) : base(itemView)
			{
				Nametxt = itemView.FindViewById<TextView>(Resource.Id.txtname1);
			}
 		}
	}
}