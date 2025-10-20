using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Group.GetGroupsCommand
{
    public class GetGroupsCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public int? SpecialId { get; set; }
        public class GetGroupsCommandHandler(Db131025Context db) : IRequestHandler<GetGroupsCommand, IEnumerable<GroupDTO>>
        {
            private readonly Db131025Context db = db;
            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupsCommand request, CancellationToken ct = default)
            {
                return request.SpecialId > 0 ? 
                    db.Groups.Where(g => g.IdSpecial == request.SpecialId).Include("Students").Include("IdSpecialNavigation").Select(g => (GroupDTO)g) 
                    :
                    db.Groups.Include("Students").Include("IdSpecialNavigation").Select(g => (GroupDTO)g);
            }
        }
    }
}
