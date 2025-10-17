using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Group.GetGroupsWOutStudentsCommand
{
    public class GetGroupsWOutStudentsCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public class GetGroupsWOutStudentsCommandHander(Db131025Context db) : IRequestHandler<GetGroupsWOutStudentsCommand, IEnumerable<GroupDTO>>
        {
            private readonly Db131025Context db = db;
            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupsWOutStudentsCommand request, CancellationToken ct = default)
            {
                return db.Groups.Include(g => g.Students).Include(g => g.IdSpecialNavigation).Where(g => g.Students.Count == 0).Select(g => (GroupDTO)g);
            }
        }
    }
}
