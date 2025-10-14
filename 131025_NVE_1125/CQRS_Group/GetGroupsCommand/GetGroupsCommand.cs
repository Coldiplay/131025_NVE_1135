using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Group.GetGroupsCommand
{
    public class GetGroupsCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public class GetGroupsCommandHandler(Db131025Context db) : IRequestHandler<GetGroupsCommand, IEnumerable<GroupDTO>>
        {
            private readonly Db131025Context db = db;
            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupsCommand request, CancellationToken ct = default)
            {
                return db.Groups.Include("Students").Include("IdSpecialNavigation").Select(g => (GroupDTO)g);
            }
        }
    }
}
