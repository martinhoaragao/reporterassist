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
	[Register ("View")]
	partial class View
	{
		[Outlet]
		AppKit.NSButton CheckFim { get; set; }

		[Outlet]
		AppKit.NSButton LoginButton { get; set; }

		[Outlet]
		AppKit.NSTextField LoginLabel { get; set; }

		[Outlet]
		AppKit.NSButton LogoutButton { get; set; }

		[Outlet]
		AppKit.NSTextField NovoTrabalhoDescricao { get; set; }

		[Outlet]
		AppKit.NSDatePicker NovoTrabalhoFim { get; set; }

		[Outlet]
		AppKit.NSDatePicker NovoTrabalhoInicio { get; set; }

		[Outlet]
		AppKit.NSTextField NovoTrabalhoTitulo { get; set; }

		[Outlet]
		AppKit.NSSecureTextField PasswordText { get; set; }

		[Outlet]
		AppKit.NSTabView TarefasView { get; set; }

		[Outlet]
		AppKit.NSPopUpButtonCell TrabalhosPop { get; set; }

		[Outlet]
		AppKit.NSTabView TrabalhosView { get; set; }

		[Outlet]
		AppKit.NSTextField UsernameText { get; set; }

		[Action ("LoginAction:")]
		partial void LoginAction (Foundation.NSObject sender);

		[Action ("LogoutAction:")]
		partial void LogoutAction (Foundation.NSObject sender);

		[Action ("NovoTrabalhoAction:")]
		partial void NovoTrabalhoAction (Foundation.NSObject sender);

		[Action ("VerTarefasAction:")]
		partial void VerTarefasAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UsernameText != null) {
				UsernameText.Dispose ();
				UsernameText = null;
			}

			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}

			if (LoginLabel != null) {
				LoginLabel.Dispose ();
				LoginLabel = null;
			}

			if (TrabalhosView != null) {
				TrabalhosView.Dispose ();
				TrabalhosView = null;
			}

			if (TarefasView != null) {
				TarefasView.Dispose ();
				TarefasView = null;
			}

			if (LogoutButton != null) {
				LogoutButton.Dispose ();
				LogoutButton = null;
			}

			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}

			if (TrabalhosPop != null) {
				TrabalhosPop.Dispose ();
				TrabalhosPop = null;
			}

			if (NovoTrabalhoTitulo != null) {
				NovoTrabalhoTitulo.Dispose ();
				NovoTrabalhoTitulo = null;
			}

			if (NovoTrabalhoDescricao != null) {
				NovoTrabalhoDescricao.Dispose ();
				NovoTrabalhoDescricao = null;
			}

			if (NovoTrabalhoInicio != null) {
				NovoTrabalhoInicio.Dispose ();
				NovoTrabalhoInicio = null;
			}

			if (NovoTrabalhoFim != null) {
				NovoTrabalhoFim.Dispose ();
				NovoTrabalhoFim = null;
			}

			if (CheckFim != null) {
				CheckFim.Dispose ();
				CheckFim = null;
			}
		}
	}
}
