using Android.App;
using Android.Views;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using System.Collections.Generic;

namespace RecordAudio {
	
	public class MapsFragment : MapFragment, IOnMapReadyCallback, ILocationListener {
		LocationManager locationManager;
		string locationProvider;
		MarkerOptions marker;
		GoogleMap map;
		
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
		}
		
		public void OnMapReady(GoogleMap map) {
			this.map = map;
		
			// Create location manager.
			InitializeLocationManager();
			locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);

			System.Diagnostics.Debug.WriteLine("LOCATION MANAGER");
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
			System.Diagnostics.Debug.WriteLine("OLÁ");
		}
		
		public override void OnPause() {
			base.OnPause();
			locationManager.RemoveUpdates(this);
			System.Diagnostics.Debug.WriteLine("ADEUS");
		}

		public void OnLocationChanged(Location location) {
			// Add marker of the current location to the map.
			marker 				= new MarkerOptions();
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

