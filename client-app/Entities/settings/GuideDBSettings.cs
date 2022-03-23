namespace LearnSchoolApp.Entities
{
    public class GuideDBSettings : IGuideDBSettings
    {
        public string GuideCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGuideDBSettings
    {
        public string GuideCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
