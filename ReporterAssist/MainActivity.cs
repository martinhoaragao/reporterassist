using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Speech;
using Java.Lang;
using System.Collections;
using System.IO;

namespace RecordAudio
{
	[Activity(Label = "Reporter Assist", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		MediaRecorder 		recorder;
		MediaPlayer 			player;
		Button 						start;
		Button 						stop;
		Button	 					timestamp;
		ListView 					timestamps;
		long 							startTimestamp;
		int audioNumber 	= 0;
		ArrayList stamps 	= new ArrayList();
		

		// Filepath of the reporter assist folder.
		static string path 							= Environment.ExternalStorageDirectory.ToString() + "/ReporterAssist";
		DirectoryInfo reporterAssistDir = new DirectoryInfo(path + "/");

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get ui components and start speech recognizer.
			start 						= FindViewById<Button>(Resource.Id.start);
			stop 							= FindViewById<Button>(Resource.Id.stop);
			timestamp 				= FindViewById<Button>(Resource.Id.timestamp);
			timestamps 				= FindViewById<ListView>(Resource.Id.timestamps);

			// Create reporter assist directory.
			reporterAssistDir.Create();

			// Start button delegate.
			start.Click += delegate {
				stop.Enabled 			= !stop.Enabled;
				start.Enabled 		= !start.Enabled;
				timestamp.Enabled = !timestamp.Enabled;

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
			};

			// Stop button delegate.
			stop.Click += delegate {
				stop.Enabled 			= !stop.Enabled;
				timestamp.Enabled = !timestamp.Enabled;	

				recorder.Stop();
				recorder.Reset();

				player.SetDataSource(path + "/audio" + audioNumber + ".3gpp");
				player.Prepare();
				player.Start();

				// Create new adapter for the list view.
				string[] aux_stamps = new string[stamps.Count];
				for (int i = 0; i < stamps.Count; i++)
					aux_stamps[i] = stamps[i].ToString();
				IListAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, aux_stamps);
				timestamps.Adapter = adapter;

				// Write timestamps to file.
				try {
					string stampsFile = path + "/stamps" + audioNumber + ".txt";

					if (!System.IO.File.Exists(stampsFile)) {
						using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stampsFile, true)) {
							for (int s = 0; s < stamps.Count; s++) writer.Write(stamps[s].ToString() + "\n");
						}	
					}
				} catch (Exception e) {
					System.Diagnostics.Debug.WriteLine("Problema a guardar ficheiro de timestamps...");
				}

				// Increase audio number.
				audioNumber++;

				// Show popup with success message.
				Toast t = Toast.MakeText(BaseContext, "Gravação Guardada.", ToastLength.Short);
				t.Show();
			};

			// Timestamp button delegate.
			timestamp.Click += delegate {
				stamps.Add((JavaSystem.CurrentTimeMillis() - startTimestamp) / 1000);
			};

			timestamps.ItemClick += (sender, e) => {
				string second = timestamps.GetItemAtPosition(e.Position).ToString();
				if (!player.IsPlaying)
				{
					player.SetDataSource(path + "/audio1.3gpp");
					player.Prepare();
					player.Start();
				}
				player.SeekTo(int.Parse(second) * 1000);
			};
		}

		protected override void OnResume() {
			base.OnResume();

			recorder 	= new MediaRecorder();
			player 		= new MediaPlayer();

			player.Completion += (sender, e) => {
				player.Reset();
				start.Enabled = !start.Enabled;
			};
		}

		protected override void OnPause() {
			base.OnPause();

			player.Release();
			recorder.Release();
			player.Dispose();
			recorder.Dispose();
			player = null;
			recorder = null;
		}
			
	}
}


