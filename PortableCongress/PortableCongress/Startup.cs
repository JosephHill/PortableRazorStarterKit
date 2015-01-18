using System;
using System.Reflection;
using System.Threading.Tasks;
using PCLStorage;
using PortableRazor;
using Plugin.EmbeddedResource;

namespace PortableCongress
{
	public class Startup
	{
		public Startup ()
		{
		}

		public static async Task Init(
			Assembly assembly, 
			IHybridWebView webView) {

			var rootFolder = FileSystem.Current.LocalStorage;

			var webroot = PortablePath.Combine (rootFolder.Path, "www");
			var dataroot = PortablePath.Combine (rootFolder.Path, "App_Data");

			var dataAccess = new DataAccess();
			dataAccess.FileName = PortablePath.Combine (dataroot, "congress.sqlite");

			var writer = new ResourceWriter (assembly);

            // Initialize database if it doesn't exist
			if (await FileSystem.Current.GetFileFromPathAsync (dataAccess.FileName) == null) {
				await writer.WriteFile ("App_Data/congress.sqlite", dataroot);
            }

            // Initialize static content and scripts in webroot if it doesn't exist
            if (await FileSystem.Current.GetFolderFromPathAsync (PortablePath.Combine (webroot, "images")) == null) {
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

