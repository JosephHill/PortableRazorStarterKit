using System;
using System.Reflection;
using System.Threading.Tasks;
using PCLStorage;
using PortableRazor;
using Plugin.EmbeddedResource;

namespace PortableCongress
{
	public class App
	{
		public App ()
		{
		}

		public static async Task Init(
			Assembly assembly, 
			IHybridWebView webView,
			IDataAccess dataAccess) {

			var rootFolder = FileSystem.Current.LocalStorage;

			var webroot = PortablePath.Combine (rootFolder.Path, "www");
			var dataroot = PortablePath.Combine (rootFolder.Path, "App_Data");

			dataAccess.FileName = PortablePath.Combine (dataroot, "congress.sqlite");

			var writer = new ResourceWriter (assembly);

			if(await rootFolder.CheckExistsAsync(dataAccess.FileName) == ExistenceCheckResult.NotFound) {
				await writer.WriteFile ("App_Data/congress.sqlite", dataroot);
				await writer.WriteFolder ("Content", webroot);
				await writer.WriteFolder ("Scripts", webroot, false);
			}

			var politicianController = new PoliticianController (webView, dataAccess);

			RouteHandler.RegisterController ("Politician", politicianController);
		}

		public static void Show() {
			var politicianController = RouteHandler.Controllers ["Politician"] as PoliticianController;
			politicianController.ShowPoliticianList ();
		}
	}
}

