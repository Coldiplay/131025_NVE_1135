using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Student.ListStudentByGroupId
{
    public class ListStudentByGroupIdCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public int GroupId { get; set; }

        public class ListStudentByGroupIdCommandHandler(Db131025Context db) : IRequestHandler<ListStudentByGroupIdCommand, IEnumerable<StudentDTO>>
        {
            private readonly Db131025Context db = db;

            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListStudentByGroupIdCommand request, CancellationToken ct = default)
            {
                return db.Students.Where(s => s.IdGroup == request.GroupId).Select(s => (StudentDTO)s);
            }
        }
    }
}
