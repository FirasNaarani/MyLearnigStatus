namespace LearnSchoolApp.Entities
{
    public class HeadOfDepramentDBSettings : IHeadOfDepramentDBSettings
    {
        public string HeadOfDepramentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHeadOfDepramentDBSettings
    {
        public string HeadOfDepramentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
