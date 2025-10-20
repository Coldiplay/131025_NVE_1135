using _131025_NVE_1125.DB;

namespace _131025_NVE_1125.CQRS_Special
{
    public partial class SpecialDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }


        public static explicit operator SpecialDTO(Special special) => new() { Id = special.Id, Title = special.Title };
    }
}
