using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            ApplicationView.PreferredLaunchViewSize = new Size(808, 442);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void Button_Clicked(object sender, RoutedEventArgs e)
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync(); // 新建一个appWindow，窗口
            Frame secondWindow = new Frame();  // 新建一个页面
            secondWindow.Navigate(typeof(SecondWindow));  // 将页面导航到第二个窗口SecondWindow.xaml
            ElementCompositionPreview.SetAppWindowContent(appWindow, secondWindow); // 将新建的窗口和页面绑定起来
            appWindow.RequestSize(new Size(220, 110));  // 设置窗口大小
            appWindow.Title = "Page2"; // 设置新窗口标题
            Point offset = new Point(20, 110);  // 设置坐标，此坐标是相对于主窗口的坐标
            appWindow.RequestMoveRelativeToCurrentViewContent(offset);  // 将第二个窗口定位到坐标位置
            await appWindow.TryShowAsync();  // 将窗口show出来
        }
    }
}
