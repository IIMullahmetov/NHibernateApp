using Microsoft.Win32;
using NHibernateApp.Commands;
using NHibernateApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NHibernateApp.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private DbRepository repository;

		#region Commands

		private DelegateCommand select;
		public ICommand Select => select ?? (select = new DelegateCommand(() => 
		{
			OpenFileDialog dialog = new OpenFileDialog()
			{
				Filter = "XML Files (*.xml)|*.xml"
			};
			dialog.ShowDialog();
			Path = dialog.FileName;
			if (Path.Replace(" ", string.Empty) != string.Empty)
			{
				repository.ReadFromFile(path);
				repository.FindGroups();
				repository.FindStudentsWith(group);	
			}
		}));
		#endregion

		#region Bindanble Properties

		private string group;
		public string Group
		{
			get =>  group;
			set
			{
				group = value;
				repository.FindStudentsWith(group);
				OnPropertyChanged("Group");
			}
		}
		public ObservableCollection<Student> Students => repository.Students;
		public ObservableCollection<string> Groups => repository.Groups;
		private string path = string.Empty;
		public string Path
		{
			get => path;
			set
			{
				path = value;
				OnPropertyChanged("Path");
			}
		}

		#endregion
		public MainWindowViewModel() => repository = new DbRepository();
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

	}
}
