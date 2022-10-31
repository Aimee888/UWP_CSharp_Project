using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamlRelateCS
{
    public sealed partial class Page1 : Page
    {
        NewPage CurrentPage;
        public Page1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //这个e.Parameter是获取传递过来的参数
            CurrentPage = (NewPage)e.Parameter;

            if (CurrentPage.PageNum == 1)
            {
                Debug.WriteLine("=============================This is Page1");
                Page1Button.Content = "This is Page1";
            }
            if (CurrentPage.PageNum == 2)
            {
                Debug.WriteLine("=============================This is Page2");
                Page1Button.Content = "This is Page2";
            }
            if (CurrentPage.PageNum == 3)
            {
                Debug.WriteLine("=============================This is Page3");
                Page1Button.Content = "This is Page3";
            }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content.ToString() == "This is Page1") {
                button.Content = "Page1 is Clicked";
            }
            if (button.Content.ToString() == "This is Page2")
            {
                button.Content = "Page2 is Clicked";
            }
            if (button.Content.ToString() == "This is Page3")
            {
                button.Content = "Page3 is Clicked";
            }
        }
    }

}
