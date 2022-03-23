namespace LearnSchoolApp.Entities
{
    public class StudentDBSettings : IStudentDBSettings
    {
        public string StudentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStudentDBSettings
    {
        string StudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
