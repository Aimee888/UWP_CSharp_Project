using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing.PrintTicket;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace XamlRelateCS
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        NewPage nextPage = new NewPage();
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(500, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync();
            appWindow.RequestSize(new Size(100, 100));
            Frame page = new Frame();
            nextPage.fra = page;
            nextPage.appwin = appWindow;
            
            
            Button button = (Button)sender;
            if (button.Name == "ToPage1")
            {
                nextPage.PageNum = 1;
                appWindow.PersistedStateId = "ToPage1";
                Debug.WriteLine("ToPage1");
            }
            else if (button.Name == "ToPage2")
            {
                nextPage.PageNum = 2;
                appWindow.PersistedStateId = "ToPage2";
                Debug.WriteLine("ToPage2");
            }
            else {
                nextPage.PageNum = 3;
                appWindow.PersistedStateId = "ToPage3";
                Debug.WriteLine("ToPage3");
            }
            page.Navigate(typeof(Page1), nextPage);
            ElementCompositionPreview.SetAppWindowContent(appWindow, page);

            Point offset = new Point(0, 130);
            appWindow.RequestMoveRelativeToCurrentViewContent(offset);

            await appWindow.TryShowAsync();
        }
    }
}
