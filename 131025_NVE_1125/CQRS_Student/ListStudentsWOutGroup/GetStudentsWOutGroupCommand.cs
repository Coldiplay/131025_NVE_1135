using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Student.ListStudentsWOutGroup
{
    public class GetStudentsWOutGroupCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public class GetStudentsWOutGroupCommandHandler(Db131025Context db) : IRequestHandler<GetStudentsWOutGroupCommand, IEnumerable<StudentDTO>>
        {
            private readonly Db131025Context db = db;
            public async Task<IEnumerable<StudentDTO>> HandleAsync(GetStudentsWOutGroupCommand request, CancellationToken ct = default)
            {
                return db.Students.Where(s => s.IdGroup == null)
                                        .Select(s => (StudentDTO)s);
            }
        }
    }
}
