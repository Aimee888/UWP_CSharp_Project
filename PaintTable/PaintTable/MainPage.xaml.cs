using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
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
        public MainPage()
        {
            this.InitializeComponent();
            test();
        }


        new class Person
        {
            public string zero { get; set; }
            public string one { get; set; }
            public string two { get; set; }
            public string three { get; set; }
            public string four { get; set; }
            public string five { get; set; }
            public string six { get; set; }
            public string seven { get; set; }
            public string eight { get; set; }
            public string nine { get; set; }
            public string ten { get; set; }
            public string eleven { get; set; }
            public string twelve { get; set; }
            public string thirteen { get; set; }
            public string fourteen { get; set; }
            public string fifteen { get; set; }

        }

        public void test()
        {
            List<Person> Persons = new List<Person>();
            for (int i = 0; i < 16; i++)
            {
                if (i == 0)
                {
                    Persons.Add(new Person()
                    {
                        zero = "00",
                        one = "01",
                        two = "02",
                        three = "03",
                        four = "04",
                        five = "05",
                        six = "06",
                        seven = "07",
                        eight = "08",
                        nine = "09",
                        ten = "0A",
                        eleven = "0B",
                        twelve = "0C",
                        thirteen = "0D",
                        fourteen = "0E",
                        fifteen = "0F",
                    });
                }
                else {
                    string a = i.ToString("X2");
                    Persons.Add(new Person()
                    {
                        zero = a,
                        one = "00",
                        two = "00",
                        three = "00",
                        four = "00",
                        five = "00",
                        six = "00",
                        seven = "00",
                        eight = "00",
                        nine = "00",
                        ten = "00",
                        eleven = "00",
                        twelve = "00",
                        thirteen = "00",
                        fourteen = "00",
                        fifteen = "00",
                    });
                }
                
            }
            dataGrid.ItemsSource = null; //This is needed before re-bind data
            dataGrid.ItemsSource = Persons;

        }

    }
}
