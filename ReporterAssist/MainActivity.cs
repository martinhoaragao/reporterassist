using Android.App;
using Android.OS;
using Android.Util;
using System.IO;

namespace RecordAudio {
  [Activity(Label = "Reporter Assist", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
		Fragment[] fragments = { new RecordFragment(), Android.Gms.Maps.MapFragment.NewInstance() };

    // Filepath of the reporter assist folder.
    static string path 							= Environment.ExternalStorageDirectory.ToString() + "/ReporterAssist";
    DirectoryInfo reporterAssistDir = new DirectoryInfo(path + "/");

    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
      // Set our view from the "main" layout resource
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      SetContentView(Resource.Layout.Main);

      // Create the tabs to be displayed.
      AddTabToActionBar("Gravação");
      AddTabToActionBar("Mapas");

      // Create reporter assist directory and set recording fragment path.
      reporterAssistDir.Create();
			RecordFragment aux = (RecordFragment) fragments[0];
			aux.setPath(path);
    }

    void AddTabToActionBar(string text) {
      ActionBar.Tab tab = ActionBar.NewTab().SetText(text);
      tab.TabSelected += TabOnTabSelected;
      ActionBar.AddTab(tab);
    }

    void TabOnTabSelected(object sender, ActionBar.TabEventArgs args) {
      ActionBar.Tab tab = (ActionBar.Tab) sender;
      Log.Debug("[TABS]", "Tab selecionada: " + tab.Text + " | " + tab.Position);
      Fragment frag = fragments[tab.Position];
      args.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
    }
  }
}


