using NHibernateApp.Views;
using System.Windows;

namespace NHibernateApp
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e) => new MainWindow().Show();
	}
}
