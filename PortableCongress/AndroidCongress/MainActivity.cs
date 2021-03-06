using System;
using Android.App;
using Android.Content;
using Android.Webkit;
using Android.OS;
using PortableCongress;

namespace AndroidCongress
{
	[Activity (Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			InitAndShow ();
		}

		private async void InitAndShow() {
			var webView = FindViewById<WebView> (Resource.Id.webView);

			await Startup.Init (new HybridWebView (webView));

			this.RunOnUiThread(() => Startup.Show ());
		}
	}
}


