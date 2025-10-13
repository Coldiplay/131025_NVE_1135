using _131025_NVE_1125.DB;

namespace _131025_NVE_1125.CQRS_Student
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public sbyte Gender { get; set; }

        public int? IdGroup { get; set; }

        public string? GroupTitle { get; set; }

        public static explicit operator StudentDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                Gender = student.Gender,
                IdGroup = student.IdGroup,
                GroupTitle = student.IdGroupNavigation?.Title
            };
        }
    }
}
