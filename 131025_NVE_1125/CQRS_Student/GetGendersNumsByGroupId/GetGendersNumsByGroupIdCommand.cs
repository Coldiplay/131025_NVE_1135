using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Student.GetGendersNumsByGroupId
{
    public class GetGendersNumsByGroupIdCommand : IRequest<GendersInfo>
    {
        public int GroupId { get; set; }

        public class GetGendersNumsByGroupIdCommandHandler(Db131025Context db) : IRequestHandler<GetGendersNumsByGroupIdCommand, GendersInfo>
        {
            private readonly Db131025Context db = db;
            public async Task<GendersInfo> HandleAsync(GetGendersNumsByGroupIdCommand request, CancellationToken ct = default)
            {
                var list = await db.Students.ToListAsync();
                int boysNum = list.Count(s => s.Gender == 1);
                int girlsNum = list.Count(s => s.Gender == 0);
                int otherNum = list.Count - boysNum - girlsNum;
                return new GendersInfo 
                {
                    NumOfBoys = boysNum,
                    NumOfGirls = girlsNum,
                    NumOfOtherGenders = otherNum
                };
            }
        }
    }
}
