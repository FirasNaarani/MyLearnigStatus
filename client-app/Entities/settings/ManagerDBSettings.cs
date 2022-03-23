namespace LearnSchoolApp.Entities
{
    public class ManagerDBSettings : IManagerDBSettings
    {
        public string ManagerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IManagerDBSettings
    {
        public string ManagerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
