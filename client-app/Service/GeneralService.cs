using LearnSchoolApp.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Service
{
    public class GeneralService
    {
        private readonly IMongoCollection<Student> _student;
        private readonly IMongoCollection<Project> _project;

        public GeneralService (IStudentDBSettings settingStudent, IProjectDBSettings settingProject)
        {
            // StudentDBSetting
            var clientStudent = new MongoClient(settingStudent.ConnectionString);
            var databaseStudent = clientStudent.GetDatabase(settingStudent.DatabaseName);
            _student = databaseStudent.GetCollection<Student>(settingStudent.StudentCollectionName);
            
            // ProjectDBSetting
            var clientProject = new MongoClient(settingProject.ConnectionString);
            var databaseProject = clientProject.GetDatabase(settingProject.DatabaseName);
            _project = databaseProject.GetCollection<Project>(settingProject.ProjectCollectionName);
        }


    }
}
