using _131025_NVE_1125.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Student.FindRepeatedStudents
{
    public class FindRepeatedStudentsCommand : IRequest<IEnumerable<IEnumerable<StudentDTO>>>
    {
        public class FindRepeatedStudentsCommandHandler(Db131025Context db) : IRequestHandler<FindRepeatedStudentsCommand, IEnumerable<IEnumerable<StudentDTO>>>
        {
            public async Task<IEnumerable<IEnumerable<StudentDTO>>> HandleAsync(FindRepeatedStudentsCommand request, CancellationToken ct = default)
            {
                var result = new List<List<StudentDTO>>();
                var students = await db.Students.Select(s => (StudentDTO)s).ToArrayAsync();
                foreach (var student in students)
                {
                    var repeatedList = students.Where(s => s.Id != student.Id
                    && student.FirstName == s.FirstName
                    && student.LastName == s.LastName
                    && student.Phone == s.Phone).ToList();
                    if (repeatedList.Count > 0)
                    {
                        if (!result.Any(l => l.Contains(student)))
                        {
                            repeatedList.Add(student);
                            result.Add(repeatedList.ToList());
                        }
                    }
                }
                return result;
            }
        }
    }
}
