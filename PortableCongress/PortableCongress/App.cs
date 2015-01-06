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

			var writer = new ResourceWriter (assembly);

			if(await rootFolder.CheckExistsAsync("congress.sqlite") == ExistenceCheckResult.NotFound) {
				await writer.WriteFile ("App_Data/congress.sqlite", rootFolder.Path);
				await writer.WriteFolder ("Content", rootFolder.Path);
				await writer.WriteFolder ("Scripts", rootFolder.Path, false);
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

