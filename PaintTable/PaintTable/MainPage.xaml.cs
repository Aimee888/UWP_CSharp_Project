using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace PaintTable
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int buttonCounter = 0;
        public MainPage()
        {
            this.InitializeComponent();
            //test();
            initial_grid();               
        }

        private void initial_grid() {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Button b = new Button();
                    b.Height = 35;
                    b.Width = 35;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.Margin = new Thickness(0, 0, 0, 0);
                    b.FontSize = 10;
                    b.Name = (i*17+j).ToString(); 
                    if (i == 0 && j == 0)
                    {
                        b.Content = "00";
                        Windows.UI.Xaml.Media.SolidColorBrush mycolor = new SolidColorBrush(Windows.UI.Colors.LightYellow);
                        b.Background = mycolor;
                        Windows.UI.Xaml.Media.SolidColorBrush mycolor1 = new SolidColorBrush(Windows.UI.Colors.Red);
                        b.Foreground = mycolor1;
                        
                    }
                    else if (i == 0 && j != 0)
                    {
                        b.Content = (j - 1).ToString("X2");
                        //b.IsEnabled = false;
                        Windows.UI.Xaml.Media.SolidColorBrush mycolor = new SolidColorBrush(Windows.UI.Colors.LightYellow);
                        b.Background = mycolor;
                        

                    }
                    else if (i != 0 && j == 0)
                    {
                        b.Content = (i - 1).ToString("X2");
                        //b.IsEnabled = false;
                        Windows.UI.Xaml.Media.SolidColorBrush mycolor = new SolidColorBrush(Windows.UI.Colors.LightYellow);
                        b.Background = mycolor;
                        
                    }
                    else
                    {
                        b.Content = "00";
                        Windows.UI.Xaml.Media.SolidColorBrush mycolor = new SolidColorBrush(Windows.UI.Colors.White);
                        b.Background = mycolor;
                    }

                    b.Click += Button_Click;
                    b.DoubleTapped += B_DoubleTapped;

                    int column = (int)(buttonCounter / 17);
                    int row = buttonCounter % 17;

                    // Check if you need to add a columns
                    if (row == 0)
                    {
                        ColumnDefinition col = new ColumnDefinition();
                        col.Width = new GridLength(column, GridUnitType.Auto);
                        myGrid.ColumnDefinitions.Add(col);
                    }
                    //Add the button
                    myGrid.Children.Add(b);
                    Grid.SetColumn(b, column);
                    Grid.SetRow(b, row);
                    buttonCounter++;
                }
            }
        }

        private void B_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e) // 鼠标双击事件
        {
            //throw new NotImplementedException(); 
            Button button = (Button)sender;
            System.Diagnostics.Debug.WriteLine(button.Name);
            positionTest.Text = button.Name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)  // 鼠标单击事件
        {
             // 此处可以通过获取button的Name得到Button的坐标，前面初始化时是根据坐标定的Name名称
            //Button button = (Button)sender;
            //System.Diagnostics.Debug.WriteLine(button.Name);
        }
    }
}
