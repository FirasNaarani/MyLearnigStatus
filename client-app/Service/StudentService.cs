using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnSchoolApp.Services
{
    public interface IStudentService
    {
        List<Student> Get();
        Boolean isValidCredentials(string username, string password);
        Boolean isValidProject(string id);
        Student Get(string id);
        Student Create(Student student);
        void UpdatePassword(string id, Student student);
        void Delete(string id);
        void Update(string id, Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _student;

        public StudentService(IStudentDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _student = database.GetCollection<Student>(settings.StudentCollectionName);
            var x = _student.Indexes;
            _student.Indexes.CreateOne(
                new CreateIndexModel<Student>(Builders<Student>.IndexKeys.Descending(model => model.username),
                new CreateIndexOptions { Unique = true })
            );
            _student.Indexes.CreateOne(
                new CreateIndexModel<Student>(Builders<Student>.IndexKeys.Descending(model => model.email),
                new CreateIndexOptions { Unique = true })
            );
            _student.Indexes.CreateOne(
                new CreateIndexModel<Student>(Builders<Student>.IndexKeys.Descending(model => model.userId),
                new CreateIndexOptions { Unique = true })
            );
        }
       
        public List<Student> Get()
        {
            var students = _student.Find(m => m.isActive).ToList();
            return students;
        }

        public Boolean isValidCredentials(string username, string password)
        {
            Student student = _student.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
            return student != null;
        }
        
        public Boolean isValidProject(string id)
        {
            Student student = _student.Find(m => m.userId == id && m.isProject == false && m.isActive == true).FirstOrDefault();
            return student != null;
        }

        public Student Get(string id)
        {
            var student = _student.Find<Student>(student => student.Id == id).FirstOrDefault();
            return student;
        }
       
        public Student Create(Student student)
        {
            student.userType = UserType.Student;
            student.isProject= false;
            student.isActive = true;
            try
            {
                _student.InsertOne(student);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate student");
                }
            }
            return student;
        }

        public void UpdatePassword(string id, Student student)
        {
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.password, student.password);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }

        public void Delete(string id)
        {
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, Student student)
        {
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.email, student.email)
                        .Set(_ => _.phone, student.phone);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }
    }
}
