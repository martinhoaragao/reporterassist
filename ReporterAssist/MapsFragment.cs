using Android.App;
using Android.Views;
using Android.OS;
using Android.Gms.Maps;

namespace RecordAudio {
	
	public class MapsFragment : MapFragment {
		private MapFragment mapFragment;
		
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			View view = inflater.Inflate(Resource.Layout.MapsFragment, null);
			mapFragment = MapFragment.NewInstance();
			FragmentTransaction tx = FragmentManager.BeginTransaction();
			tx.Add(Resource.Id.frameLayout1, mapFragment);
			tx.Commit();
			return view;
		}	
	}
	
}

