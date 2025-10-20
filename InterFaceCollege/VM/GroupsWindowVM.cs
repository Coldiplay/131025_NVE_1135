using InterFaceCollege.Model;
using InterFaceCollege.VM.VMTools;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace InterFaceCollege.VM
{
    public class GroupsWindowVM : BaseVM
    {
        private HttpClient client;
        private List<GroupDTO>? groups;
        private GroupDTO newGroup = new();
        private int? specialId;
        private List<SpecialDTO> specials;
        private SpecialDTO? selectedSpecial;

        public List<GroupDTO>? Groups
        {
            get => groups;
            set
            {
                groups = value;
                Signal();
            }
        }
        public GroupDTO NewGroup
        {
            get => newGroup;
            set
            {
                newGroup = value;
                Signal();
            }
        }
        public int? SpecialId
        {
            get => specialId;
            set
            {
                specialId = value;
                Signal();
            }
        }
        public List<SpecialDTO> Specials
        {
            get => specials;
            set
            {
                specials = value;
                Signal();
            }
        }
        public SpecialDTO? SelectedSpecial
        {
            get => selectedSpecial;
            set
            {
                selectedSpecial = value;
                Signal();
            }
        }

        public CommandVM ClearNewGroup { get; set; }
        public CommandVM GetGroups { get; set; }
        public CommandVM GetEmptyGroups { get; set; }
        public CommandVM AddGroup { get; set; }
        public CommandVM GetGroupsBySpecialId { get; set; }

        public GroupsWindowVM()
        {
            if (client != null)
                LoadList();
            InitilizeCommands();
        }

        private async void LoadList()
        {
            await GetGroupsAsync(null);
            await GetSpecialsAsync();
        }

        private void InitilizeCommands() 
        {
            GetGroups = new CommandVM(async () =>await GetGroupsAsync(null), () => true);
            GetEmptyGroups = new CommandVM(async () => await GetEmptyGroupsAsync(), () => true);
            AddGroup = new CommandVM(async () =>
            {
                await AddGroupAsync(NewGroup);
                NewGroup = new();
                await GetGroupsAsync(null);
            }, () => true);
            ClearNewGroup = new CommandVM(() =>
            {
                NewGroup = new();
            }, () => true);
            GetGroupsBySpecialId = new CommandVM(async() => await GetGroupsAsync(SpecialId), () => true);
        }

        public async Task GetGroupsAsync(int? specialId) =>
            Groups = await client.GetFromJsonAsync<List<GroupDTO>>($"Groups/GetGroups?specialId={specialId}");
        public async Task GetEmptyGroupsAsync() =>
            Groups = await client.GetFromJsonAsync<List<GroupDTO>>("Groups/GetGroupsWOutStudents");
        private async Task AddGroupAsync(GroupDTO group)
        {
            group.IdSpecial = SelectedSpecial?.Id;
            var result = await client.PostAsJsonAsync("Groups/AddGroup", group);
            if (result.StatusCode != System.Net.HttpStatusCode.Created)
            {
                MessageBox.Show("Произошла ошибка. Группа не была добавлена");
            }
        }
        private async Task GetSpecialsAsync()
        {
            Specials = (await client.GetFromJsonAsync<List<SpecialDTO>>("Specials/GetSpecials")).ToList();
        }
        public void Set(HttpClient client)
        {
            this.client = client;
            LoadList();
        }
    }
}
