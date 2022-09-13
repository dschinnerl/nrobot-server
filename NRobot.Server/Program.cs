using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using log4net;
using log4net.Repository;
using NRobot.Server.Imp;
using NRobot.Server.Imp.Config;

namespace NRobot.Server
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{

		//log4net
		// private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
      ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
			var fileInfo = new FileInfo(@"log4net.config");
	    log4net.Config.XmlConfigurator.Configure(repository, fileInfo);

			Log.Debug("Starting NRobot Server");

			var trayapp = new TrayApplication();
			// if (trayapp.IsRunning)
			// {
			// 	Application.Run(trayapp);
			// }
			// Application.Exit();
		}

	}

	public class TrayApplication // : ApplicationContext
	{
    private NRobotService _service;
    private NRobotServerConfig _serviceConfig;
		public bool IsRunning;

		//constructor
		public TrayApplication()
		{
	      Console.WriteLine(String.Format("NRobot.Server version {0}",Assembly.GetExecutingAssembly().GetName().Version));

			  _serviceConfig = NRobotServerConfig.LoadXmlConfiguration();
			 	_service = new NRobotService(_serviceConfig);
			 	_service.StartAsync();

				Console.WriteLine("Press <ENTER> to stop.");
				Console.ReadLine(); // hack
			 	_service.Stop();
				Console.WriteLine("NRobotService done.");
		}

		/// <summary>
		/// Handles keywords context menu click
		/// </summary>
		public void KeywordsOptionClick(object sender, EventArgs e)
		{
			// Process.Start(String.Format("http://localhost:{0}",_serviceConfig.Port));
		}

	}
}
