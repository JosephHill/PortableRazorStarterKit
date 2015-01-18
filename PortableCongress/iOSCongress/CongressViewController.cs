using System;
using CoreGraphics;
using System.Reflection;
using Foundation;
using UIKit;
using PortableCongress;

namespace iOSCongress
{
	public partial class CongressViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public CongressViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitAndShow ();
		}

		private async void InitAndShow() {
			await Startup.Init (
				typeof(PoliticianController).Assembly,
				new HybridWebView (webView));

			this.InvokeOnMainThread(() => Startup.Show ());
		}
	}
}

