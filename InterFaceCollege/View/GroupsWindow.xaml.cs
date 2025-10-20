using InterFaceCollege.VM;
using System.Net.Http;
using System.Windows;

namespace InterFaceCollege.View
{
    /// <summary>
    /// Логика взаимодействия для GroupsWindow.xaml
    /// </summary>
    public partial class GroupsWindow : Window
    {
        public GroupsWindow(HttpClient client)
        {
            InitializeComponent();
            var vm = new GroupsWindowVM();
            vm.Set(client);
            DataContext = vm;
        }
    }
}
