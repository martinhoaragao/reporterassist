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
			NovoTrabalhoLabelState.Hidden = true;
			NovoTrabalhoStateLabel.Hidden = true;
			NovoTrabalhoConluirButton.Hidden = true;

			//Adiciona Tarefa

			AddTarefaLabel.Hidden = true;

			//Visualizar Tarefa
			VisualizarTituloTarefaLabel.Hidden = true;
			VisualizarEstadoTarefaLabel.Hidden = true;
			VisualizarDescricaoTarefaLabel.Hidden = true;
			VisualizarTituloTarefaText.Hidden = true;
			VisualizarDescricaoTarefaText.Hidden = true;
			ConcluidoTarefaLabel.Hidden = true;
			ConcluirTarefaButton.Hidden = true;
			EditarTarefaButton.Hidden = true;
			RemoverTarefaButton.Hidden = true;
			GravarTarefaButton.Hidden = true;
			EditarRemoverTarefaLabel.Hidden = true;

			AnexosPop.RemoveAllItems();
			TrabalhosPop.RemoveAllItems();
			TarefasPop.RemoveAllItems();
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
			Dictionary<int, Project> projetos = reporter.Projects;
			TrabalhosPop.RemoveAllItems();
			foreach (Project proj in projetos.Values)
			{
				TrabalhosPop.AddItem(proj.Title);
			}
		}

		private void updateAnexosPop()
		{
			Dictionary<int, Project> projectos = reporter.Projects;
			if (tituloUsado != null)
			{
				foreach (Project proj in projectos.Values)
				{
					if (proj.Title.Equals(tituloUsado))
					{
						Dictionary<int, Audio> audio = proj.Audios;
						Dictionary<int, Image> imagem = proj.Images;
						Dictionary<int, Video> video = proj.Videos;
						foreach (Audio aud in audio.Values)
						{
							AnexosPop.AddItem(aud.Path);
						}
						foreach (Image img in imagem.Values)
						{
							AnexosPop.AddItem(img.Path);
						}
						foreach (Video vid in video.Values)
						{
							AnexosPop.AddItem(vid.Path);
						}
					}
				}
			}
			else AnexosPop.RemoveAllItems();
		}

		private void updateTarefasPop()
		{
			TarefasPop.RemoveAllItems();
			Dictionary<int, Project> projectos = reporter.Projects;
			Dictionary<int, Task> tasks = new Dictionary<int, Task>();
			foreach (Project proj in projectos.Values)
			{
				if(proj.Title.Equals(tituloUsado))
				{
					tasks = proj.Tasks;
					foreach (Task task in tasks.Values)
					{
						TarefasPop.AddItem(task.Title);
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
				Dictionary<int, Project> projetos = reporter.Projects;
				bool teste = false;

				//testar se não existe titulo igual
				foreach (Project proj in projetos.Values)
				{
					if (titulo.Equals(proj.Title))
					{
						teste = true;
						AdicionarTrabalhoLabel.StringValue = "Título do Trabalho já usado";
						AdicionarTrabalhoLabel.Hidden = false;
						break;
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
					int result = DateTime.Compare(DateTime.Now, inicio);
					State state = new State();
					if (result < 0)
					{
						state.Type = "por fazer";
					}
					else state.Type = "a fazer";

					reporter.AddProject(titulo, descricao, inicio, fim, state);
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
			tituloUsado = TrabalhosPop.TitleOfSelectedItem;
			if (tituloUsado != null)
			{
				NovoTrabalhoConluirButton.Hidden = true;

				updateTarefasPop();
				updateAnexosPop();

				DataFimTrabalho.Hidden = true;
				DataFimLabel.Hidden = true;
				EdicaoRemocaoTrabalhoLabel.Hidden = true;
				GuardarEdicaoTrabalho.Hidden = true;
				CheckEditarDataFimButton.Hidden = true;
				AddTarefaLabel.Hidden = true;

				TarefasView.Hidden = false;

				DateTime aux = new DateTime();
				string titulo = TrabalhosPop.TitleOfSelectedItem;
				Dictionary<int, Project> projetos = reporter.Projects;
				foreach (Project proj in projetos.Values)
				{
					if (titulo.Equals(proj.Title))
					{
						TituloTrabalho.StringValue = proj.Title;
						DescricaoTrabalho.StringValue = proj.Description;
						DataInicioTrabalho.DateValue = DateTimeToNSDate(proj.Begin);
						NovoTrabalhoLabelState.StringValue = proj.State.Type;
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
				NovoTrabalhoLabelState.Hidden = false;
				NovoTrabalhoStateLabel.Hidden = false;
			}
		}

		partial void EditarTrabalho(NSObject sender)
		{
			NovoTrabalhoLabelState.Hidden = false;
			NovoTrabalhoStateLabel.Hidden = false;
			NovoTrabalhoConluirButton.Hidden = false;
			DataFimLabel.Hidden = true;
			DataFimTrabalho.Hidden = false;
			GuardarEdicaoTrabalho.Hidden = false;
			EdicaoRemocaoTrabalhoLabel.Hidden = true;
			CheckEditarDataFimButton.Hidden = false;
		}

		partial void GuardarEdicaoAction(NSObject sender)
		{
			Dictionary<int, Project> projectos = reporter.Projects;
			bool teste = false;
			foreach (Project proj in projectos.Values)
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
				foreach (Project proj in projectos.Values)
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
						if (NovoTrabalhoConluirButton.State == NSCellStateValue.On)
						{
							State state = new State();
							state.Type = "feito";
							proj.State = state;
						}
						else 
						{
							int result = DateTime.Compare(DateTime.Now, proj.End);
							State state = new State();
							if (result < 0)
							{
								state.Type = "por fazer";
								proj.State = state;

							}
							else
							{
								state.Type = "a fazer";
								proj.State = state;
							}
						}

						tituloUsado = TituloTrabalho.StringValue;
						updateTrabalhosPopUp();
						EdicaoRemocaoTrabalhoLabel.StringValue = "Trabalho editado com sucesso";
						EdicaoRemocaoTrabalhoLabel.Hidden = false;
						NovoTrabalhoConluirButton.Hidden = false;
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
			NovoTrabalhoLabelState.Hidden = true;
			NovoTrabalhoStateLabel.Hidden = true;
			NovoTrabalhoConluirButton.Hidden = true;

			Dictionary<int, Project> projetos = reporter.Projects;

			reporter.RemoveProject(tituloUsado);
			updateTrabalhosPopUp();

			EdicaoRemocaoTrabalhoLabel.StringValue = "Trabalho removido com sucesso";
			EdicaoRemocaoTrabalhoLabel.Hidden = false;
		}

		partial void AdicionarTarefa(NSObject sender)
		{
			Dictionary<int, Project> projetos = reporter.Projects;
			bool teste = false;


			foreach (Project proj in projetos.Values)
			{
				if (proj.Title.Equals(tituloUsado))
				{
					foreach (Task task in proj.Tasks.Values)
					{
						if (task.Title.Equals(NovaTarefaTitulo.StringValue))
						{
							AddTarefaLabel.StringValue = "Título de inválido";
							teste = true;
							break;
						}
					}
					break;
				}
			}
			if (!teste)
			{
				int idProject = 0;
				foreach (Project proj in projetos.Values)
				{
					if (tituloUsado.Equals(proj.Title))
					{
						idProject = proj.Id;
						reporter.AddTask(idProject, NovaTarefaTitulo.StringValue, NovaTarefaDescricao.StringValue, "nao concluido");
						AddTarefaLabel.StringValue = "Tarefa adicionado com sucesso";
						break;
					}
				}
				updateTarefasPop();
			}
			AddTarefaLabel.Hidden = false;
		}

		partial void VisualizarTarefasAction(NSObject sender)
		{
			GravarTarefaButton.Hidden = true;
			EditarRemoverTarefaLabel.Hidden = true;
			tarefaUsada = TarefasPop.TitleOfSelectedItem;
			if (tarefaUsada != null)
			{
				VisualizarTituloTarefaText.StringValue = tarefaUsada;
				foreach (Project proj in reporter.Projects.Values)
				{
					if (proj.Title.Equals(tituloUsado))
					{
						foreach (Task task in proj.Tasks.Values)
						{
							if (task.Title.Equals(tarefaUsada))
							{
								VisualizarDescricaoTarefaText.StringValue = task.Description;
								ConcluidoTarefaLabel.StringValue = task.State.Type;
							}
						}
					}
				}

				VisualizarDescricaoTarefaLabel.Hidden = false;
				VisualizarTituloTarefaLabel.Hidden = false;
				VisualizarEstadoTarefaLabel.Hidden = false;
				VisualizarTituloTarefaText.Hidden = false;
				VisualizarDescricaoTarefaText.Hidden = false;
				ConcluidoTarefaLabel.Hidden = false;
				ConcluirTarefaButton.Hidden = true;
				EditarTarefaButton.Hidden = false;
				RemoverTarefaButton.Hidden = false;
			}
		}

		partial void EditarTarefaAction(NSObject sender)
		{
			GravarTarefaButton.Hidden = false;
			ConcluirTarefaButton.Hidden = false;
		}

		partial void GravarTarefaAction(NSObject sender)
		{
			bool teste = false;

			foreach (Project proj in reporter.Projects.Values)
			{
				if (proj.Title.Equals(tituloUsado))
				{
					foreach (Task task in proj.Tasks.Values)
					{
						if (task.Title.Equals(VisualizarTituloTarefaText.StringValue) && !tarefaUsada.Equals(VisualizarTituloTarefaText.StringValue))
						{
							EditarRemoverTarefaLabel.StringValue = "Título de inválido";
							teste = true;
							break;
						}
					}
					break;
				}
			}
			if (!teste)
			{
				foreach (Project proj in reporter.Projects.Values)
				{
					if (proj.Title.Equals(tituloUsado))
					{
						foreach (Task task in proj.Tasks.Values)
						{
							if (task.Title.Equals(tarefaUsada))
							{
								task.Title = VisualizarTituloTarefaText.StringValue;
								task.Description = VisualizarDescricaoTarefaText.StringValue;
								if (ConcluirTarefaButton.State == NSCellStateValue.On)
								{
									State state = new State();
									state.Type = "concluido";
									task.State.Type = state.Type;
								}
								EditarRemoverTarefaLabel.StringValue = "Tarefa editada com sucesso";
								break;
							}
						}
						break;
					}
				}
			}
			else EditarRemoverTarefaLabel.StringValue = "Erro -> Titulo já usado";
			EditarRemoverTarefaLabel.Hidden = false;
			updateTarefasPop();
		}

		partial void RemoverTarefaAction(NSObject sender)
		{
			VisualizarTituloTarefaLabel.Hidden = true;
			VisualizarEstadoTarefaLabel.Hidden = true;
			VisualizarDescricaoTarefaLabel.Hidden = true;
			VisualizarTituloTarefaText.Hidden = true;
			VisualizarDescricaoTarefaText.Hidden = true;
			ConcluidoTarefaLabel.Hidden = true;
			ConcluirTarefaButton.Hidden = true;
			EditarTarefaButton.Hidden = true;
			RemoverTarefaButton.Hidden = true;
			GravarTarefaButton.Hidden = true;
			int index = -1;
			EditarRemoverTarefaLabel.StringValue = "Tarefa inexistente";
			foreach (Project proj in reporter.Projects.Values)
			{
				if (proj.Title.Equals(tituloUsado))
				{
					foreach (Task task in proj.Tasks.Values)
					{
						if (task.Title.Equals(VisualizarTituloTarefaText.StringValue))
						{
							index = task.Id;
							proj.RemoveTask(index);
							updateTarefasPop();
							EditarRemoverTarefaLabel.StringValue = "Tarefa removida com sucesso";
							break;
						}
					}
					break;
				}
			}
			EditarRemoverTarefaLabel.Hidden = false;

		}

	}
}
