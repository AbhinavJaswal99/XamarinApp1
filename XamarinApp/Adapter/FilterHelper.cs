using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;


namespace XamarinApp.Adapter
{
	// all the logic will be done in this helper class.
	public class FilterHelper : Filter
	{
		static List<string> currentList;
		static SearchAdapter adapter;

		

		internal static Filter newInstance(List<string> currentList, SearchAdapter searchAdapter)
		{
			//FilterHelper.adapter = adapter;
			FilterHelper.currentList = currentList;
			return new FilterHelper();
		}

		protected override FilterResults PerformFiltering(ICharSequence constraint)
		{
			FilterResults filterResults = new FilterResults();
			if(constraint != null && constraint.Length() > 0)
			{
				string query = constraint.ToString().ToUpper();
				List<string> foundfilters = new List<string>();
				for(int i = 0; i < currentList.Count(); i++)
				{
					string galaxy = currentList[i];
					if (galaxy.ToUpper().Contains(query.ToString()))
					{
						foundfilters.Add(galaxy);
					}
				}
				filterResults.Count = foundfilters.Count;// Using size property to count....
				filterResults.Values = foundfilters.ToString();// here i am converting Java.Lang.object to String..
		    }
			else
			{
				filterResults.Count = currentList.Count;
				filterResults.Values = currentList.ToString();// here i am converting Java.Lang.object to String..

			}
			return filterResults;
		}

		protected override void PublishResults(ICharSequence constraint, FilterResults results)
		{
			
		//adapter.setGalaxies((List<string>)results.Values);
		//adapter.NotifyDataSetChanged();
		}
	}
}