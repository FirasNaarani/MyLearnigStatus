using LearnSchoolApp.Entities;
using LearnSchoolApp.Infra;
using LearnSchoolApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _student;

        public StudentService(IManagerDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _student = database.GetCollection<Student>(settings.ManagerCollectionName);
            //_student.Indexes.CreateOne(
            //    new CreateIndexModel<Student>(Builders<Student>.IndexKeys.Descending(model => model.username),
            //    new CreateIndexOptions { Unique = true })
            //);
            //_student.Indexes.CreateOne(
            //    new CreateIndexModel<Student>(Builders<Student>.IndexKeys.Descending(model => model.email),
            //    new CreateIndexOptions { Unique = true })
            //);
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

        public Student Get(string id)
        {
            var student = _student.Find<Student>(student => student.Id == id).FirstOrDefault();
            //student.password = "";
            return student;
        }
        public Student Create(Student student)
        {
            student.isActive = true;
            student.password = EncryptDecryptPassword.EncryptPlainTextToCipherText(student.password);
            try
            {
                _student.InsertOne(student);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate user");
                }
            }
            student.password = "";
            return student;
        }

        public void UpdatePassword(string id, UpdatePassword manager)
        {
            manager.password = EncryptDecryptPassword.EncryptPlainTextToCipherText(manager.password);
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.password, manager.password);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }

        internal void Delete(string id)
        {
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, UpdateUser manager)
        {
            var filter = Builders<Student>.Filter.Where(_ => _.Id == id);
            var update = Builders<Student>.Update
                        .Set(_ => _.email, manager.email)
                        .Set(_ => _.name, manager.name)
                        .Set(_ => _.username, manager.username);
            var options = new FindOneAndUpdateOptions<Student>();
            _student.FindOneAndUpdate(filter, update, options);
        }
    }
}
