using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
// using System.Windows.Forms;
using System.Reflection;
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
			// var fileInfo = new FileInfo(@"/Volumes/EXT256GB/Users/dietmar/Documents/Avocodo/Projects/KTM/robotframework-playground/nrobot-server/NRobot.Server/bin/Debug/netcoreapp3.1/log4net.config");
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

      //       try
			// {
	    //     	//start service
			  _serviceConfig = NRobotServerConfig.LoadXmlConfiguration();
			 	_service = new NRobotService(_serviceConfig);
			 	_service.StartAsync();

				// Thread.Sleep(1); // hack
				Console.WriteLine("Press <ENTER> to stop.");
				Console.ReadLine(); // hack
				Console.WriteLine("NRobotService done.");
			// 	IsRunning = true;

			// }
			// catch (Exception e)
			// {
			// 	MessageBox.Show(String.Format("Unable to start NRobot.Server: \n\n{0}",e.ToString()),"Error",MessageBoxButtons.OK);
			// 	IsRunning = false;
			// }

		}

		/// <summary>
		/// Handles exit context menu click
		/// </summary>
		public void ExitOptionClick(object sender, EventArgs e)
		{
			// Application.Exit();
		}

		/// <summary>
		/// Handles about context menu click
		/// </summary>
		public void AboutOptionClick(object sender, EventArgs e)
		{
			// var frm = new AboutForm();
			// frm.ShowDialog();
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
