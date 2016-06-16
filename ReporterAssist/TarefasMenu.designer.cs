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
	[Register ("TarefasMenu")]
	partial class TarefasMenu
	{
		[Outlet]
		AppKit.NSButton EditarTarefaAction { get; set; }

		[Outlet]
		AppKit.NSButton NovaTarefaAction { get; set; }

		[Outlet]
		AppKit.NSButton RemoverTarefarAction { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NovaTarefaAction != null) {
				NovaTarefaAction.Dispose ();
				NovaTarefaAction = null;
			}

			if (EditarTarefaAction != null) {
				EditarTarefaAction.Dispose ();
				EditarTarefaAction = null;
			}

			if (RemoverTarefarAction != null) {
				RemoverTarefarAction.Dispose ();
				RemoverTarefarAction = null;
			}
		}
	}
}
