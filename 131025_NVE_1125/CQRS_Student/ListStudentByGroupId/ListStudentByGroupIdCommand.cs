using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Student.ListStudentByGroupId
{
    public class ListStudentByGroupIdCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public int GroupId { get; set; }

        public class ListStudentByGroupIdCommandHandler : IRequestHandler<ListStudentByGroupIdCommand, IEnumerable<StudentDTO>>
        {
            private readonly Db131025Context db;
            public ListStudentByGroupIdCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListStudentByGroupIdCommand request, CancellationToken ct = default)
            {
                return await db.Students.Where(s => s.IdGroup == request.GroupId).Select(s => (StudentDTO)s).ToListAsync();
            }
        }
    }
}
