namespace LearnSchoolApp.Entities
{
    public class ProjectProposalDBSettings : IProjectProposalDBSettings
    {
        public string ProjectProposalCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProjectProposalDBSettings
    {
        public string ProjectProposalCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
