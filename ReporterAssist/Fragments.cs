using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RecordAudio {

	public class RecordFragment : Fragment {
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			View view = inflater.Inflate(Resource.Layout.SampleFragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).Text = "Texto 1";
			return View;
		}
	}
	
	public class MapsFragment : Fragment {
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			View view = inflater.Inflate(Resource.Layout.SampleFragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).Text = "Texto 2";
			return View;
		}
	}
	
}

