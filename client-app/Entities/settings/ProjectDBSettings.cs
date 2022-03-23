namespace LearnSchoolApp.Entities
{
    public class ProjectDBSettings : IProjectDBSettings
    {
        public string ProjectCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProjectDBSettings
    {
        public string ProjectCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
