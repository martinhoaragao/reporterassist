// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;

using Shared;
using Foundation;
using AppKit;

namespace Mac
{
	public partial class View : NSViewController
	{
		//variaveis globais
		private Shared.ReporterAssist reporter;
		private string tituloUsado; //Para permitir editar um trabalho
		private string tarefaUsada; //Para permitir editar uma tarefa

		private bool logado = false;

		public View (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			//Botoes login e logout
			LoginLabel.Hidden = true;
			LogoutButton.Hidden = true;
			//Views
			TrabalhosView.Hidden = true;
			TarefasView.Hidden = true;

			//Adicionar Trabalho
			AdicionarTrabalhoLabel.Hidden = true;

			//Visualizar trabalho
			TituloTrabalho.Hidden = true;
			DescricaoTrabalho.Hidden = true;
			DataInicioTrabalho.Hidden = true;
			DataFimLabel.Hidden = true;
			DescricaoLabel.Hidden = true;
			TituloLabel.Hidden = true;
			DataFimTrabalho.Hidden = true;
			DataFimNameLabel.Hidden = true;
			EditarTrabalhoButton.Hidden = true;
			RemoverTrabalhoButton.Hidden = true;
			DataInicioLabel.Hidden = true;
			EdicaoRemocaoTrabalhoLabel.Hidden = true;
			GuardarEdicaoTrabalho.Hidden = true;
			CheckEditarDataFimButton.Hidden = true;
		}

		//NSDATE to DateTime converter
	
		private DateTime NSDateToDateTime(NSDate date)
		{
			DateTime reference = new DateTime(2001, 1, 1, 0, 0, 0);
			DateTime currentDate = reference.AddSeconds(date.SecondsSinceReferenceDate);
			DateTime localDate = currentDate.ToLocalTime();
			return localDate;
		}

		//DateTime to NSDATE converter

		private NSDate DateTimeToNSDate(DateTime date)
		{
			if (date.Kind == DateTimeKind.Unspecified)
				date = DateTime.SpecifyKind(date, DateTimeKind.Local);
			return (NSDate)date;
		}

		private void updateTrabalhosPopUp()
		{
			List<Project> projetos = reporter.Projects;
			TrabalhosPop.RemoveAllItems();
			foreach (Project proj in projetos)
			{
				TrabalhosPop.AddItem(proj.Title);
			}
		}

		private void updateTarefasPop()
		{
			TarefasPop.RemoveAllItems();
			List<Project> projectos = reporter.Projects;
			List<Task> tasks = new List<Task>();
			foreach (Project proj in projectos)
			{
				if(proj.Title.Equals(tituloUsado))
				{
					tasks = proj.Tasks;
					foreach (Task taks in tasks)
					{
						TarefasPop.AddItem(taks.Title);
					}
					break;
				}
			}

		}

		partial void LoginAction(NSObject sender)
		{
			reporter = new Shared.ReporterAssist();
			string user = UsernameText.StringValue;
			string pass = PasswordText.StringValue;

			//Fazer login FIXIT

			//login bem sucedido
			logado = true;

			if (logado)
			{
				TrabalhosView.Hidden = false;
				LoginButton.Hidden = true;
				LogoutButton.Hidden = false;
				LoginLabel.StringValue = "Autenticado com sucesso";
				LoginLabel.Hidden = false;

				updateTrabalhosPopUp();
			}
			else {
				LoginLabel.StringValue = "Username e/ou Password errada";
				LoginLabel.Hidden = false;
			}

		}

		partial void LogoutAction(NSObject sender)
		{
			reporter = null;
			LoginButton.Hidden = false;
			LoginLabel.StringValue = "Lougout feito com sucesso";
			LogoutButton.Hidden = true;
			LoginLabel.Hidden = false;
			TrabalhosView.Hidden = true;
			TarefasView.Hidden = true;
		}

		partial void NovoTrabalhoAction(NSObject sender)
		{
			if (!NovoTrabalhoTitulo.Equals("")){
				string titulo = NovoTrabalhoTitulo.StringValue;
				List<Project> projetos = reporter.Projects;
				bool teste = false;

				//testar se não existe titulo igual
				foreach (Project proj in projetos)
				{
					if (titulo.Equals(proj.Title))
					{
						teste = true;
						AdicionarTrabalhoLabel.StringValue = "Título do Trabalho já usado";
						AdicionarTrabalhoLabel.Hidden = false;
					}
				}
				if (teste == false)
				{
					string descricao = NovoTrabalhoDescricao.StringValue;
					DateTime inicio = NSDateToDateTime(NovoTrabalhoInicio.DateValue);
					DateTime fim;
					if (CheckFim.State == NSCellStateValue.On)
					{
						fim = NSDateToDateTime(NovoTrabalhoFim.DateValue);
					}
					else {
						fim = new DateTime();
					}
					reporter.AddProject(titulo, descricao, inicio, fim);
					updateTrabalhosPopUp();
					AdicionarTrabalhoLabel.StringValue = "Trabalho Adicionado com sucesso";
					AdicionarTrabalhoLabel.Hidden = false;
				}
				else
				{
					AdicionarTrabalhoLabel.StringValue = "Trabalho já existente";
					AdicionarTrabalhoLabel.Hidden = false;
				}
			}
		}

		partial void VerTarefasAction(NSObject sender)
		{
			updateTarefasPop();
			DataFimTrabalho.Hidden = true;
			DataFimLabel.Hidden = true;
			EdicaoRemocaoTrabalhoLabel.Hidden = true;
			GuardarEdicaoTrabalho.Hidden = true;
			CheckEditarDataFimButton.Hidden = true;

			TarefasView.Hidden = false;

			DateTime aux = new DateTime();
			tituloUsado = TrabalhosPop.TitleOfSelectedItem;
			string titulo = TrabalhosPop.TitleOfSelectedItem;
			List<Project> projetos = reporter.Projects;
			foreach (Project proj in projetos)
			{
				if (titulo.Equals(proj.Title))
				{
					TituloTrabalho.StringValue = proj.Title;
					DescricaoTrabalho.StringValue = proj.Description;
					DataInicioTrabalho.DateValue = DateTimeToNSDate(proj.Begin);
					if (proj.End.Equals(aux))
					{
						DataFimLabel.Hidden = false;
					}
					else 
					{
						DataFimTrabalho.DateValue = DateTimeToNSDate(proj.End);
						DataFimTrabalho.Hidden = false;
					}
					break; //break cicle
				}
			}

			TituloTrabalho.Hidden = false;
			DescricaoTrabalho.Hidden = false;
			DataInicioTrabalho.Hidden = false;
			DataFimNameLabel.Hidden = false;
			DescricaoLabel.Hidden = false;
			TituloLabel.Hidden = false;
			EditarTrabalhoButton.Hidden = false;
			RemoverTrabalhoButton.Hidden = false;
			DataInicioLabel.Hidden = false;
		}

		partial void EditarTrabalho(NSObject sender)
		{
			DataFimLabel.Hidden = true;
			DataFimTrabalho.Hidden = false;
			GuardarEdicaoTrabalho.Hidden = false;
			EdicaoRemocaoTrabalhoLabel.Hidden = true;
			CheckEditarDataFimButton.Hidden = false;
		}

		partial void GuardarEdicaoAction(NSObject sender)
		{
			List<Project> projectos = reporter.Projects;
			bool teste = false;
			foreach (Project proj in projectos)
			{
				if (TituloTrabalho.StringValue.Equals(proj.Title) && !TituloTrabalho.StringValue.Equals(tituloUsado))
				{
					teste = true;
					EdicaoRemocaoTrabalhoLabel.StringValue = "Titulo de trabalho já usado";
					EdicaoRemocaoTrabalhoLabel.Hidden = false;
				}
			}
			if (teste == false)
			{
				foreach (Project proj in projectos)
				{
					if (tituloUsado.Equals(proj.Title))
					{

						proj.Title = TituloTrabalho.StringValue;
						proj.Description = DescricaoTrabalho.StringValue;
						proj.Begin = NSDateToDateTime(DataInicioTrabalho.DateValue);

						if (CheckEditarDataFimButton.State == NSCellStateValue.On)
						{
							proj.End = NSDateToDateTime(DataFimTrabalho.DateValue);
						}
						else {
							proj.End = new DateTime();
						}

						tituloUsado = TituloTrabalho.StringValue;
						updateTrabalhosPopUp();
						EdicaoRemocaoTrabalhoLabel.StringValue = "Trabalho editado com sucesso";
						EdicaoRemocaoTrabalhoLabel.Hidden = false;
						break;
					}
				}
			}
		}


		partial void RemoverTrabalho(NSObject sender)
		{
			TituloTrabalho.Hidden = true;
			DescricaoTrabalho.Hidden = true;
			DataInicioTrabalho.Hidden = true;
			DataFimLabel.Hidden = true;
			DescricaoLabel.Hidden = true;
			TituloLabel.Hidden = true;
			DataFimTrabalho.Hidden = true;
			DataFimNameLabel.Hidden = true;
			EditarTrabalhoButton.Hidden = true;
			RemoverTrabalhoButton.Hidden = true;
			DataInicioLabel.Hidden = true;
			GuardarEdicaoTrabalho.Hidden = true;
			CheckEditarDataFimButton.Hidden = true;

			List<Project> projetos = reporter.Projects;
			foreach (Project proj in projetos)
			{
				if (tituloUsado.Equals(proj.Title))
				{
					reporter.RemoveProject(projetos.IndexOf(proj));
					updateTrabalhosPopUp();
					break;
				}
			}


			EdicaoRemocaoTrabalhoLabel.StringValue = "Trabalho removido com sucesso";
			EdicaoRemocaoTrabalhoLabel.Hidden = false;
		}

		partial void AdicionarTarefa(NSObject sender)
		{
			List<Project> projetos = reporter.Projects;
			Project aux = new Project();
			Random rnd = new Random();
			int id = rnd.Next(0, 10000);
			int index = -1;
			foreach (Project proj in projetos)
			{
				if (tituloUsado.Equals(proj.Title))
				{
					aux = proj;
					index = projetos.IndexOf(proj);
					reporter.RemoveProject(index);
					break;
				}
			}
			aux.AddTask(id, NovaTarefaTitulo.StringValue, NovaTarefaDescricao.StringValue);
			reporter.AddProject(aux);
			updateTarefasPop();
		}




	}
}