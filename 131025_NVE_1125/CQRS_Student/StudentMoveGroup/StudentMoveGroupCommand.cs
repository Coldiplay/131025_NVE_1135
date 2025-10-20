using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _131025_NVE_1125.CQRS_Student.StudentMoveGroup
{
    public class StudentMoveGroupCommand : IRequest<Unit>
    {
        public int StudentId { get; set; }
        public int? GroupId { get; set; }

        public class StudentMoveGroupCommandHandler(Db131025Context db) : IRequestHandler<StudentMoveGroupCommand, Unit>
        {
            public async Task<Unit> HandleAsync(StudentMoveGroupCommand request, CancellationToken ct = default)
            {
                if (request.StudentId < 1 || await db.Students.AnyAsync(s => s.Id == request.StudentId))
                    throw new Exception("Студент для перемещения не выбран");
                (await db.Students.FirstAsync(s => s.Id == request.StudentId)).IdGroup = request.GroupId;
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
