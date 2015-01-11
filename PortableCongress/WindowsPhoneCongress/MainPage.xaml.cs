using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsPhoneCongress.Resources;

using PortableRazor;
using PortableCongress;
using Congress;

namespace WindowsPhoneCongress
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            InitAndShow();
        }

        private async void InitAndShow()
        {
            await PortableCongress.App.Init(
                typeof(PoliticianController).Assembly,
                new HybridWebView(WebView),
                new DataAccess());

            this.Dispatcher.BeginInvoke(() => PortableCongress.App.Show());
        }
    }
}