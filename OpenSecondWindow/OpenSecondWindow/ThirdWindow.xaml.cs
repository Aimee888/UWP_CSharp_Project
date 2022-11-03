using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace OpenSecondWindow
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ThirdWindow : Page
    {
        public ThirdWindow()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void Clicked_Button(object sender, RoutedEventArgs e)
        {
            var s = ApplicationView.GetForCurrentView();
            s.TryResizeView(new Size { Width = 400, Height = 200 });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(100, 60));
            Thread.Sleep(10);
            var s = ApplicationView.GetForCurrentView();
            s.TryResizeView(new Size { Width = 400, Height = 200 }); 
        }
    }
}
