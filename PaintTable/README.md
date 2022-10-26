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
当前画出了16 * 16的 表格，但是单元格大小不能很紧凑的在一起。  
XAML
~~~xml
<GridView Grid.Row="0" ItemsSource="{Binding Source={StaticResource cvsProjects}}">
            <GridView.ItemContainerStyle>
                <Style TargetType="GridViewItem">
                    <Setter Property="Margin" Value="0"/>
                </Style>
            </GridView.ItemContainerStyle>
            <GridView.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" FontWeight="Bold" />
                    </StackPanel>
                </DataTemplate>
            </GridView.ItemTemplate>
            <GridView.ItemsPanel>
                <ItemsPanelTemplate>
                    <ItemsWrapGrid MaximumRowsOrColumns="16" />
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
