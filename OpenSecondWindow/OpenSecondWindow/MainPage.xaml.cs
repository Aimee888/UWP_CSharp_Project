using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Core.Preview;
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

using System.Management;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace OpenSecondWindow
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // 设置主窗口的大小
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(442, 221));
            //ApplicationView.PreferredLaunchViewSize = new Size(808, 442);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            // 当点击主窗口的关闭按钮时触发
            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += (s, e) =>
            {
                var deferral = e.GetDeferral();

                //Do extra task here
                System.Diagnostics.Debug.WriteLine("Do extra task here");
                //Environment.Exit(0);

                deferral.Complete();
            };
        }


        // Track open app windows in a Dictionary.
        public static Dictionary<UIContext, AppWindow> AppWindows { get; set; }
            = new Dictionary<UIContext, AppWindow>();

        private async void Button_Clicked(object sender, RoutedEventArgs e)
        {

            //Frame secondWindow = new Frame();  // 新建一个页面
            //secondWindow.Navigate(typeof(SecondWindow));  // 将页面导航到第二个窗口SecondWindow.xaml
            ////FrameContainer.Navigate(typeof(SecondWindow));  // 将页面导航到第二个窗口SecondWindow.xaml
            ////this.FrameContainer.Children.Add(secondWindow);

            //AppWindow appWindow = await AppWindow.TryCreateAsync(); // 新建一个appWindow，窗口
            //appWindow.RequestMoveAdjacentToCurrentView();
            //appWindow.RequestSize(new Size(220, 110));  // 设置窗口大小
            //appWindow.Title = "Color picker";

            ////ElementCompositionPreview.SetAppWindowContent(appWindow, secondWindow); // 将新建的窗口和页面绑定起来
            //ElementCompositionPreview.SetAppWindowContent(appWindow, secondWindow); // 将新建的窗口和页面绑定起来


            ////// 定位方案1
            ////Point offset = new Point(20, 110);  // 设置坐标，此坐标是相对于主窗口的坐标
            ////appWindow.RequestMoveRelativeToCurrentViewContent(offset);  // 将第二个窗口定位到坐标位置

            //// 定位方案2
            ////appWindow.RequestMoveAdjacentToCurrentView(); // 将第二个窗口定位到主窗口旁边

            //// 关闭窗口时释放资源
            //appWindow.Closed += delegate
            //{
            //    FrameContainer.Content = null;
            //    appWindow = null;
            //};

            //await appWindow.TryShowAsync();  // 将窗口show出来

            // 创建新窗口和线程
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(SecondWindow), null);
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);

        }

    }
}
