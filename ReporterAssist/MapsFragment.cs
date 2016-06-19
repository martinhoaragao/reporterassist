using Android.App;
using Android.Views;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Widget;
using System.Collections.Generic;

namespace RecordAudio {

	public class MapsFragment : Fragment, IOnMapReadyCallback, ILocationListener {
		MapFragment mapFragment;
		GoogleMap map;
		LocationManager locationManager;
		string locationProvider;
		bool viewCreated;
		
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			viewCreated = false;

			InitializeLocationManager();
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			if (!viewCreated) {
				View view = inflater.Inflate(Resource.Layout.MapsFragment, null);

				this.mapFragment 	= (MapFragment) FragmentManager.FindFragmentById(Resource.Id.mapContainer);
				this.map 					= mapFragment.Map;
				this.viewCreated 	= true;
				this.mapFragment.GetMapAsync(this);
			
				return view;
			} else {
				return View.FindViewById(Resource.Layout.MapsFragment);
			}
		}
		
		public void OnMapReady(GoogleMap map) {
		}
	
		void InitializeLocationManager() {
			locationManager = (LocationManager) Application.Context.GetSystemService(Android.Content.Context.LocationService);
			Criteria criteriaForLocationService = new Criteria { Accuracy = Accuracy.Fine };
			IList<string> providers = locationManager.GetProviders(criteriaForLocationService, true);
			
			if (providers.Count > 0) {
				locationProvider = providers[0];
			} else {
				locationProvider = "";
			}
			System.Diagnostics.Debug.WriteLine("Using " + locationProvider + ".");
		}
	
		public override void OnResume() {
			base.OnResume();
			locationManager.RequestLocationUpdates(locationProvider, 0, 0, (ILocationListener) this);
			System.Diagnostics.Debug.WriteLine("OLÁ");
		}
		
		public override void OnPause() {
			base.OnPause();
			locationManager.RemoveUpdates((ILocationListener) this);
			System.Diagnostics.Debug.WriteLine("ADEUS");
		}
		
		public void OnLocationChanged(Location location) {
			// Add marker of the current location to the map.
			var marker 		= new MarkerOptions();
			var position 	= new LatLng(10, 10);
			var title 		= "Localização Atual";
			marker.SetPosition(position);
			marker.SetTitle(title);
			map.AddMarker(marker);
			
			System.Diagnostics.Debug.WriteLine("LAT: " + location.Latitude + " | LONG: " + location.Longitude);
		}
		
		public void OnProviderDisabled(string provider) {}
		
		public void OnProviderEnabled(string provider) {}
		
		public void OnStatusChanged(string provider, Availability status, Bundle extras) {}
	}	
}

