namespace InterFaceCollege.Model
{
    public class GroupDTO : BaseModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdSpecial { get; set; }

        public string? SpecialtyTitle { get; set; }
        public int? StudentsCount { get; set; }
    }
}
