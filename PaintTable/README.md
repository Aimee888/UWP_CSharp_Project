# UWP绘制一个表格  
参考链接：https://www.likecs.com/show-308504507.html  
http://www.manongjc.com/detail/52-xolstugucnisbky.html  
https://learn.microsoft.com/zh-CN/uwp/api/windows.ui.xaml.controls.gridview?view=winrt-22621  



## 安装Microsoft.Toolkit.Uwp.UI.Controls.DataGrid库  
第一步：右击项目--》【管理NulGet程序包】--》搜索【Microsoft.Toolkit.Uwp.UI.Controls.DataGrid】--》【浏览】--》【安装】  
![](./pic/1.png)  
![](./pic/2.png)  
![](./pic/3.png)  

## 使用GridView画表格  
解决了单元格大小不能很紧凑的在一起。但是无法显示框线，也不知道如何调用双击事件。Game Over  
XAML
~~~xml
<GridView ItemsSource="{Binding Source={StaticResource cvsProjects}}" IsItemClickEnabled="True" ItemClick="ItemClick" SelectionMode="None">
            <GridView.ItemContainerStyle>
                <Style TargetType="GridViewItem">
                    <Setter Property="Margin" Value="0"/>
                    <!--<Setter Property="Padding" Value="0" />
                    <Setter Property="HorizontalContentAlignment" Value="Center" />
                    <Setter Property="VerticalContentAlignment" Value="Center" />-->
                </Style>
            </GridView.ItemContainerStyle>
            <GridView.ItemTemplate>
                <DataTemplate>
                    <StackPanel BorderBrush="Black" Orientation="Vertical" Height="30" Width="30">
                        <TextBlock Text="{Binding Name}" 
                               FontSize="12"/>
                    </StackPanel>
                    <!--<Border Height="30" Width="30">
                        <TextBlock Text="{Binding Name}" 
                               FontSize="12"/>
                    </Border>-->
                    <!--<TextBlock Text="{Binding Name}" FontWeight="Bold" FontSize="8"/>-->
                    <!--<StackPanel>
                        <TextBlock MaxWidth="30" MaxHeight="30" HorizontalAlignment="Center" Text="{Binding Name}"/>
                    </StackPanel>-->
                </DataTemplate>
            </GridView.ItemTemplate>

            <GridView.ItemsPanel>
                <ItemsPanelTemplate>
                    <!--<ItemsWrapGrid MaximumRowsOrColumns="16" ItemWidth="25" ItemHeight="25" />-->
                    <!--<WrapGrid MaximumRowsOrColumns="16" ItemWidth="30" ItemHeight="30" Orientation="Horizontal" VerticalChildrenAlignment="Center" />-->
                    <WrapGrid MaximumRowsOrColumns="16" ItemWidth="30" ItemHeight="30" />
                </ItemsPanelTemplate>
            </GridView.ItemsPanel>

        </GridView>
~~~

CS
~~~C#
public sealed partial class MainPage : Page
    {
        //DateTime startDate = DateTime.Now;
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(800, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            PopulateProjects();

        }

        private void PopulateProjects()
        {
            List<Project> Projects = new List<Project>();

            //// 第一列
            Project newProject = new Project();

            for (int i = 0; i < 16; i++)
            {
                newProject = new Project();
                //newProject.Name = "01";
                for (int j = 0; j < 16; j++)
                {
                    newProject.Activities.Add(new Activity()
                    { Name = "00" });
                }
                Projects.Add(newProject);
            }

            cvsProjects.Source = Projects;
        }

    }

    public class Project
    {
        public Project()
        {
            Activities = new ObservableCollection<Activity>();
        }

        public string Name { get; set; }
        public ObservableCollection<Activity> Activities { get; private set; }
    }

    public class Activity
    {
        public string Name { get; set; }
    }
~~~
