using LearnSchoolApp.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Services
{
    public interface IProjectService
    {
        List<Project> Get();
        Boolean isDuplicateProject(string name, string studentId);
        Project Get(string id);
        Project GetMyProject(string id);
        Project Create(Project project);
        void Delete(string id);
        void Update(string id, Project project);
    }
    public class ProjectService : IProjectService
    {
        private readonly IMongoCollection<Project> _project;

        public ProjectService(IProjectDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _project = database.GetCollection<Project>(settings.ProjectCollectionName);
        }
        public List<Project> Get()
        {
            var Projects = _project.Find(m => m.isActive).ToList();
            return Projects;
        }

        //public Boolean isValidCredentials(string username, string password)
        //{
        //    Project Project = _project.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
        //    return Project != null;
        //}

        public Boolean isDuplicateProject(string name, string studentId)
        {
            Project Project = _project.Find(m => m.name == name || m.studentId == studentId && m.isActive == true).FirstOrDefault();
            return Project != null;
        }

        public Project Get(string id)
        {
            var Project = _project.Find<Project>(Project => Project.Id == id).FirstOrDefault();
            return Project;
        }

        public Project GetMyProject(string id)
        {
            var Project = _project.Find<Project>(Project => Project.studentId == id || Project.assistantStudentId == id).FirstOrDefault();
            return Project;
        }

        public Project Create(Project project)
        {
            project.isActive = true;
            project.isPass = true;
            project.projectStatuses = new List<Status>();
            project.guidingStatuses = new List<Status>();
            project.projectProposal = new ProjectProposal();
            try
            {
                _project.InsertOne(project);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate project");
                }
            }
            return project;
        }

        //public void UpdatePassword(string id, UpdatePassword manager)
        //{
        //    manager.password = EncryptDecryptPassword.EncryptPlainTextToCipherText(manager.password);
        //    var filter = Builders<Project>.Filter.Where(_ => _.Id == id);
        //    var update = Builders<Project>.Update
        //                .Set(_ => _.password, manager.password);
        //    var options = new FindOneAndUpdateOptions<Project>();
        //    _project.FindOneAndUpdate(filter, update, options);
        //}

        public void Delete(string id)
        {
            var filter = Builders<Project>.Filter.Where(_ => _.Id == id);
            var update = Builders<Project>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Project>();
            _project.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, Project project)
        {
            var filter = Builders<Project>.Filter.Where(_ => _.Id == id);
            var update = Builders<Project>.Update
                        .Set(_ => _.studentName, project.studentName)
                        .Set(_ => _.studentId, project.studentId)
                        .Set(_ => _.assistantStudentName, project.assistantStudentName)
                        .Set(_ => _.assistantStudentId, project.assistantStudentId)
                        .Set(_ => _.guideId, project.guideId)
                        .Set(_ => _.guideName, project.guideName)
                        .Set(_ => _.name, project.name);
            var options = new FindOneAndUpdateOptions<Project>();
            _project.FindOneAndUpdate(filter, update, options);
        }
    }
}
