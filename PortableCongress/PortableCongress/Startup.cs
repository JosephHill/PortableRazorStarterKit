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

		public static async Task Init (IHybridWebView webView) {

			var rootFolder = FileSystem.Current.LocalStorage;

			var dataAccess = new DataAccess();
			var dataroot = PortablePath.Combine (rootFolder.Path, "App_Data");
			dataAccess.FileName = PortablePath.Combine (dataroot, "congress.sqlite");

			var writer = new ResourceWriter(typeof(Startup).GetTypeInfo().Assembly);

            // Initialize database if it doesn't exist
			if (await FileSystem.Current.GetFileFromPathAsync (dataAccess.FileName) == null) {
				await writer.WriteFile ("App_Data/congress.sqlite", dataroot);
            }

            // Initialize static content and scripts in webroot if it doesn't exist
            if (await FileSystem.Current.GetFolderFromPathAsync (PortablePath.Combine (webView.BasePath, "images")) == null) {
				await writer.WriteFolder ("Content", webView.BasePath);
				await writer.WriteFolder ("Scripts", webView.BasePath, false);
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

