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
		MapFragment 			mapFragment;
		GoogleMap 				map;
		LocationManager 	locationManager;
		string 						locationProvider;
		bool 							viewCreated;
		
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			InitializeLocationManager();
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var mf = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.mapContainer);
			if (mf != null) {
				FragmentManager.BeginTransaction().Remove(mf).Commit();
				FragmentManager.PopBackStack();
			}
			View view = inflater.Inflate(Resource.Layout.MapsFragment, null);

			this.mapFragment 	= (MapFragment)FragmentManager.FindFragmentById(Resource.Id.mapContainer);
			this.map 					= mapFragment.Map;
			this.viewCreated 	= true;
			this.mapFragment.GetMapAsync(this);
			Button markLocationButton = view.FindViewById<Button>(Resource.Id.markLocationButton);
			markLocationButton.Click += MarkLocationButtonClicked;

			return view;
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
		}
		
		public override void OnPause() {
			base.OnPause();
			locationManager.RemoveUpdates(this);
		}
		
		public void OnLocationChanged(Location location) {
			// Add marker of the current location to the map.
			var marker 		= new MarkerOptions();
			var position 	= new LatLng(location.Latitude, location.Longitude);
			var title 		= "Localização Atual";
			marker.SetPosition(position);
			marker.SetTitle(title);
			map.AddMarker(marker);

			CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(position, 10);
			map.AnimateCamera(cameraUpdate);
			
			System.Diagnostics.Debug.WriteLine("LAT: " + location.Latitude + " | LONG: " + location.Longitude);
		}
		
		public void OnProviderDisabled(string provider) {}
		
		public void OnProviderEnabled(string provider) {}
		
		public void OnStatusChanged(string provider, Availability status, Bundle extras) {}
		
		private void MarkLocationButtonClicked(object sender, System.EventArgs args) {
			// Request location update.
			locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, (ILocationListener) this);
			locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, (ILocationListener) this);
		}
	}	
}

