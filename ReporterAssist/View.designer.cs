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
		AppKit.NSTextField AdicionarTrabalhoLabel { get; set; }

		[Outlet]
		AppKit.NSButton CheckEditarDataFimButton { get; set; }

		[Outlet]
		AppKit.NSButton CheckFim { get; set; }

		[Outlet]
		AppKit.NSTextField DataFimLabel { get; set; }

		[Outlet]
		AppKit.NSTextField DataFimNameLabel { get; set; }

		[Outlet]
		AppKit.NSDatePicker DataFimTrabalho { get; set; }

		[Outlet]
		AppKit.NSTextField DataInicioLabel { get; set; }

		[Outlet]
		AppKit.NSDatePicker DataInicioTrabalho { get; set; }

		[Outlet]
		AppKit.NSTextField DescricaoLabel { get; set; }

		[Outlet]
		AppKit.NSTextField DescricaoTrabalho { get; set; }

		[Outlet]
		AppKit.NSTextField EdicaoRemocaoTrabalhoLabel { get; set; }

		[Outlet]
		AppKit.NSButton EditarTrabalhoButton { get; set; }

		[Outlet]
		AppKit.NSButton GuardarEdicaoTrabalho { get; set; }

		[Outlet]
		AppKit.NSButton LoginButton { get; set; }

		[Outlet]
		AppKit.NSTextField LoginLabel { get; set; }

		[Outlet]
		AppKit.NSButton LogoutButton { get; set; }

		[Outlet]
		AppKit.NSTextField NovaTarefaDescricao { get; set; }

		[Outlet]
		AppKit.NSTextField NovaTarefaTitulo { get; set; }

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
		AppKit.NSButton RemoverTrabalhoButton { get; set; }

		[Outlet]
		AppKit.NSPopUpButtonCell TarefasPop { get; set; }

		[Outlet]
		AppKit.NSTabView TarefasView { get; set; }

		[Outlet]
		AppKit.NSTextField TituloLabel { get; set; }

		[Outlet]
		AppKit.NSTextField TituloTrabalho { get; set; }

		[Outlet]
		AppKit.NSPopUpButtonCell TrabalhosPop { get; set; }

		[Outlet]
		AppKit.NSTabView TrabalhosView { get; set; }

		[Outlet]
		AppKit.NSTextField UsernameText { get; set; }

		[Outlet]
		AppKit.NSButton VisualizarTarefasAction { get; set; }

		[Outlet]
		AppKit.NSButton VisualizarTarefasButton { get; set; }

		[Action ("AdicionarTarefa:")]
		partial void AdicionarTarefa (Foundation.NSObject sender);

		[Action ("EditarTrabalho:")]
		partial void EditarTrabalho (Foundation.NSObject sender);

		[Action ("GuardarEdicaoAction:")]
		partial void GuardarEdicaoAction (Foundation.NSObject sender);

		[Action ("LoginAction:")]
		partial void LoginAction (Foundation.NSObject sender);

		[Action ("LogoutAction:")]
		partial void LogoutAction (Foundation.NSObject sender);

		[Action ("NovoTrabalhoAction:")]
		partial void NovoTrabalhoAction (Foundation.NSObject sender);

		[Action ("RemoverTrabalho:")]
		partial void RemoverTrabalho (Foundation.NSObject sender);

		[Action ("VerTarefasAction:")]
		partial void VerTarefasAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (NovaTarefaDescricao != null) {
				NovaTarefaDescricao.Dispose ();
				NovaTarefaDescricao = null;
			}

			if (NovaTarefaTitulo != null) {
				NovaTarefaTitulo.Dispose ();
				NovaTarefaTitulo = null;
			}

			if (VisualizarTarefasAction != null) {
				VisualizarTarefasAction.Dispose ();
				VisualizarTarefasAction = null;
			}

			if (VisualizarTarefasButton != null) {
				VisualizarTarefasButton.Dispose ();
				VisualizarTarefasButton = null;
			}

			if (TarefasPop != null) {
				TarefasPop.Dispose ();
				TarefasPop = null;
			}

			if (CheckEditarDataFimButton != null) {
				CheckEditarDataFimButton.Dispose ();
				CheckEditarDataFimButton = null;
			}

			if (GuardarEdicaoTrabalho != null) {
				GuardarEdicaoTrabalho.Dispose ();
				GuardarEdicaoTrabalho = null;
			}

			if (EdicaoRemocaoTrabalhoLabel != null) {
				EdicaoRemocaoTrabalhoLabel.Dispose ();
				EdicaoRemocaoTrabalhoLabel = null;
			}

			if (AdicionarTrabalhoLabel != null) {
				AdicionarTrabalhoLabel.Dispose ();
				AdicionarTrabalhoLabel = null;
			}

			if (DataFimLabel != null) {
				DataFimLabel.Dispose ();
				DataFimLabel = null;
			}

			if (RemoverTrabalhoButton != null) {
				RemoverTrabalhoButton.Dispose ();
				RemoverTrabalhoButton = null;
			}

			if (EditarTrabalhoButton != null) {
				EditarTrabalhoButton.Dispose ();
				EditarTrabalhoButton = null;
			}

			if (DataFimNameLabel != null) {
				DataFimNameLabel.Dispose ();
				DataFimNameLabel = null;
			}

			if (TituloLabel != null) {
				TituloLabel.Dispose ();
				TituloLabel = null;
			}

			if (DescricaoLabel != null) {
				DescricaoLabel.Dispose ();
				DescricaoLabel = null;
			}

			if (DataInicioLabel != null) {
				DataInicioLabel.Dispose ();
				DataInicioLabel = null;
			}

			if (TituloTrabalho != null) {
				TituloTrabalho.Dispose ();
				TituloTrabalho = null;
			}

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

			if (TarefasView != null) {
				TarefasView.Dispose ();
				TarefasView = null;
			}

			if (DataFimTrabalho != null) {
				DataFimTrabalho.Dispose ();
				DataFimTrabalho = null;
			}

			if (DataInicioTrabalho != null) {
				DataInicioTrabalho.Dispose ();
				DataInicioTrabalho = null;
			}

			if (DescricaoTrabalho != null) {
				DescricaoTrabalho.Dispose ();
				DescricaoTrabalho = null;
			}
		}
	}
}