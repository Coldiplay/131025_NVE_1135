using InterFaceCollege.Model;
using InterFaceCollege.VM.VMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterFaceCollege.VM
{
    public class GroupsWindowVM : BaseVM
    {
        private HttpClient client;
        private List<GroupDTO>? groups;
        private GroupDTO newGroup = new();

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

        public CommandVM ClearNewGroup { get; set; }
        public CommandVM GetGroups { get; set; }
        public CommandVM GetEmptyGroups { get; set; }
        public CommandVM AddGroup { get; set; }

        public GroupsWindowVM()
        {
            if (client != null)
                LoadList();
        }

        private async void LoadList()
        {
            await GetGroupsAsync();
        }

        private async void InitilizeCommands() 
        {
            GetGroups = new CommandVM(async () => await GetGroupsAsync(), () => true);
            GetEmptyGroups = new CommandVM(async () => await GetEmptyGroupsAsync(), () => true);
            AddGroup = new CommandVM(async () => await AddGroupAsync(NewGroup), () => true);
            ClearNewGroup = new CommandVM(() =>
            {
                NewGroup.Title = null;
                NewGroup.IdSpecial = null;
            }, () => true);
        }



        private async Task GetGroupsAsync() =>
            Groups = await client.GetFromJsonAsync<List<GroupDTO>>($"Groups/GetGroups");
        private async Task GetEmptyGroupsAsync() =>
            Groups = await client.GetFromJsonAsync<List<GroupDTO>>($"Groups/GetGroupsWOutStudents");
        private async Task AddGroupAsync(GroupDTO group)
        {
            var result = await client.PostAsJsonAsync("Groups/AddGroup", group);
            if (result.StatusCode != System.Net.HttpStatusCode.Created)
                MessageBox.Show("Произошла ошибка. Группа не была добавлена");
        }
        public void Set(HttpClient client) => this.client = client;
    }
}
