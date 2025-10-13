using _131025_NVE_1125.DB;

namespace _131025_NVE_1125.CQRS_Group
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdSpecial { get; set; }

        public string? SpecialtyTitle { get; set; }
        public int? StudentsCount { get; set; }


        public static explicit operator GroupDTO(Group group)
        {
            return new GroupDTO
            {
                Id = group.Id,
                Title = group.Title,
                IdSpecial = group.IdSpecial,
                SpecialtyTitle = group.IdSpecialNavigation?.Title,
                StudentsCount = group.Students.Count
            };
        }
    }
}
