using System.Text.Json.Serialization;

namespace InterFaceCollege.Model
{
    public class StudentDTO : BaseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [JsonIgnore]
        public string FullName => $"{LastName} {FirstName}";

        public string Phone { get; set; } = null!;

        public sbyte Gender { get; set; }

        [JsonIgnore]
        public string GetGender 
        {
            get
            {
                string gender = "Гендер: ";
                gender += Gender switch
                {
                    0 => "Женский",
                    1 => "Мужской",
                    _ => "Другое",
                };
                return gender;
            }
        }

        public int? IdGroup { get; set; }

        public string? GroupTitle { get; set; }
    }
}
