/**	Fragment used to record audio files with timestamps.
	*	Also writes them to disk.
	*/

using System.Collections;
using Java.Lang;

using Android.App;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RecordAudio {
	public class RecordFragment : Fragment {
		Button startButton;
		Button stopButton;
		Button timestampButton;
		ListView timestampsListView;
		ArrayList stamps;
		int audioNumber;
		long startTimestamp;
		MediaRecorder recorder;
		MediaPlayer player;
		string path;
	
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Initialize other variables.
			audioNumber = 0;
			stamps 			= new ArrayList();
			recorder 		= new MediaRecorder();
			player 			= new MediaPlayer();
			
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			View view = inflater.Inflate(Resource.Layout.RecordingFragment, null);
			
			// Initialize all UI variables.
			startButton 				= view.FindViewById<Button>(Resource.Id.startButton);
			stopButton 					= view.FindViewById<Button>(Resource.Id.stopButton);
			timestampButton 		= view.FindViewById<Button>(Resource.Id.timestampButton);
			timestampsListView 	= view.FindViewById<ListView>(Resource.Id.timestampsListView);
			startButton.Click 						+= startButtonClicked;
			stopButton.Click 							+= stopButtonClicked;
			timestampButton.Click	 				+= timestampButtonClicked;
			timestampsListView.ItemClick 	+= timestampClicked;

			// Stop button and timestamp button should be disabled in the beggining.
			stopButton.Enabled 			= false;
			timestampButton.Enabled = false;
			
			return view;
		}
		
		public override void OnResume() {
			base.OnResume();

			recorder = new MediaRecorder();
			player = new MediaPlayer();
			
			player.Completion += (sender, e) => {
				player.Reset();
				startButton.Enabled = !startButton.Enabled;
			};
		}
		
		public override void OnPause() {
			base.OnPause();

			player.Release();
			recorder.Release();
			player.Dispose();
			recorder.Dispose();
			player = null;
			recorder = null;
		}
		
		/** When start button is clicked. */
 		protected void startButtonClicked (object sender, System.EventArgs args) {
      stopButton.Enabled 			= !stopButton.Enabled;
      startButton.Enabled 		= !startButton.Enabled;
      timestampButton.Enabled = !timestampButton.Enabled;

      // Configure recorder.
      recorder.SetAudioSource(AudioSource.Mic);
      recorder.SetOutputFormat(OutputFormat.ThreeGpp);
      recorder.SetAudioEncoder(AudioEncoder.AmrNb);
      recorder.SetOutputFile(path + "/audio" + audioNumber + ".3gpp");
      recorder.Prepare();
      recorder.Start();

      // Set initial timestamp and clean timestamps arraylist.
      startTimestamp = JavaSystem.CurrentTimeMillis();
      stamps.Clear();
    }
    
    /** When stop button is clicked. */
    protected void stopButtonClicked(object sender, System.EventArgs args) {
      stopButton.Enabled 			= !stopButton.Enabled;
      timestampButton.Enabled = !timestampButton.Enabled;

      recorder.Stop();
      recorder.Reset();

      player.SetDataSource(path + "/audio" + audioNumber + ".3gpp");
      player.Prepare();
      player.Start();

      // Create new adapter for the list view.
      string[] aux_stamps = new string[stamps.Count];
      for (int i = 0; i < stamps.Count; i++)
        aux_stamps[i] = stamps[i].ToString();
      	IListAdapter adapter 				= new ArrayAdapter<string>(Context, 
				Android.Resource.Layout.SimpleListItem1, aux_stamps);
      timestampsListView.Adapter 	= adapter;

      // Write timestamps to file.
      try {
        string stampsFile = path + "/stamps" + audioNumber + ".txt";
        if (!System.IO.File.Exists(stampsFile))
        {
          using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stampsFile, true))
          {
            for (int s = 0; s < stamps.Count; s++) writer.Write(stamps[s].ToString() + "\n");
          }
        }
        
        // Increase audio number.
        audioNumber++;

        // Show popup with success message.
        Toast t = Toast.MakeText(Application.Context, "Gravação Guardada.", ToastLength.Short);
        t.Show();
      } catch (Java.Lang.Exception e) {
        System.Diagnostics.Debug.WriteLine("Problema a guardar ficheiro de timestamps...");
      }
    }
    
    /** When timestamp button is clicked. */
    protected void timestampButtonClicked(object sender, System.EventArgs args) {
      stamps.Add((JavaSystem.CurrentTimeMillis() - startTimestamp) / 1000);
    }
    
    /** When timestamp is clicked. */
    protected void timestampClicked(object sender, AdapterView.ItemClickEventArgs args) {
			string second = timestampsListView.GetItemAtPosition(args.Position).ToString();
			
			// Reset player if it is not playing.
			if (!player.IsPlaying) {
				player.SetDataSource(path + "/audio" + audioNumber + ".3gpp");
				player.Prepare();
				player.Start();
			}
			player.SeekTo(int.Parse(second) * 1000);
		}
    
    public void setPath(string path) { this.path = path; }
	}
}

