// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Mac
{
	[Register ("NewWorkMenu")]
	partial class NewWorkMenu
	{
		[Outlet]
		AppKit.NSButton SaveNewWorkAction { get; set; }

		[Outlet]
		static AppKit.NSTextField TrabalhoTitulo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SaveNewWorkAction != null) {
				SaveNewWorkAction.Dispose ();
				SaveNewWorkAction = null;
			}

			if (TrabalhoTitulo != null) {
				string titulo = TrabalhoTitulo.StringValue;
			}
		}
	}
}
