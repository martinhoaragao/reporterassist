
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Shared;

namespace RecordAudio {
	public class ProjectsFragment : Fragment {
		ListView projectsListView;
		ReporterAssist reporterAssist;
	
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			View view = inflater.Inflate(Resource.Layout.ProjectsFragment, null);

			projectsListView 					= view.FindViewById<ListView>(Resource.Id.projectsListView);
			IListAdapter adapter 			= new ArrayAdapter<string>(Application.Context,
					Android.Resource.Layout.SimpleListItem1, 
					new string[] { "Reportagem Tua", "Entrevista Orlando Belo", "Apresentação LI4" });
			projectsListView.Adapter 	= adapter;

			return view;
		}
	}
}

