using InterFaceCollege.Model;
using InterFaceCollege.View;
using InterFaceCollege.VM.VMTools;
using System.Net.Http;
using System.Net.Http.Json;

namespace InterFaceCollege.VM
{
    public class MainWindowVM : BaseVM
    {
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:7031/api/") };


        private List<BaseModel>? selectedList;

        public List<BaseModel>? SelectedList
        {
            get => selectedList;
            set
            {
                selectedList = value;
                Signal();
            }
        }
        public CommandVM SetToStudents { get; set; }
        public CommandVM SetToStudentsWOutGroup { get; set; }
        public CommandVM SetToRepeatedStudents { get; set; }


        public CommandVM OpenGroupsWindow { get; set; }
        public int GroupId { get; set; } = 1;

        public MainWindowVM()
        {
            //GroupId = 1;
            InitilizeCommands();


            //LoadList();
        }
        private void InitilizeCommands()
        {
            SetToStudents = new CommandVM(async () => await GetStudentsAsync(GroupId), () => true);
            SetToStudentsWOutGroup = new CommandVM(async () => await GetStudentsWOutGroupAsync(), () => true);
            SetToRepeatedStudents = new CommandVM(async () => await FindRepeatedStudentsAsync(), () => true);
            OpenGroupsWindow = new CommandVM(() =>
            {
                var window = new GroupsWindow(client);
               if ( window.ShowDialog() == true)
                    window.Num
                
                LoadList();
            }, () => true);
        }


        private async void LoadList()
        {
            await GetStudentsAsync(GroupId);
        }
        private async Task GetStudentsAsync(int idGroup) =>
            SelectedList = (await client.GetFromJsonAsync<List<StudentDTO>>($"Students/GetStudentsByGroupIndex/{idGroup}"))?
            .Select(s => (BaseModel)s).ToList();
        private async Task GetStudentsWOutGroupAsync() =>
            SelectedList = (await client.GetFromJsonAsync<List<StudentDTO>>($"Students/GetStudentsWOutGroup"))?
            .Select(s => (BaseModel)s).ToList();
        private async Task FindRepeatedStudentsAsync()
        {
            var lists = await client.GetFromJsonAsync<List<List<StudentDTO>>>($"Students/FindRepeatedStudents");
            SelectedList = new();
            List<BaseModel> baseModels = new List<BaseModel>();
            for (int i = 0; i < lists?.Count; i++)
                lists[i].ForEach(s => baseModels?.Add(s));
            SelectedList = baseModels;
        }



    }
}
