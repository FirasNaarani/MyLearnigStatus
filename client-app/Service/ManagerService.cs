using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnSchoolApp.Services
{
    public interface IManagerService
    {
        List<Manager> Get();
        Boolean isValidCredentials(string username, string password);
        Manager Authenticate(string username);
        Manager Get(string id);
        Manager Create(Manager student);
        void UpdatePassword(string id, Manager manager);
        void Delete(string id);
        void Update(string id, Manager manager);
    }
    public class ManagerService : IManagerService
    {
        private readonly IMongoCollection<Manager> _managers;

        public ManagerService(IManagerDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _managers = database.GetCollection<Manager>(settings.ManagerCollectionName);
            var x = _managers.Indexes;
            _managers.Indexes.CreateOne(
                new CreateIndexModel<Manager>(Builders<Manager>.IndexKeys.Descending(model => model.username),
                new CreateIndexOptions { Unique = true })
            );
            _managers.Indexes.CreateOne(
                new CreateIndexModel<Manager>(Builders<Manager>.IndexKeys.Descending(model => model.email),
                new CreateIndexOptions { Unique = true })
            );
            _managers.Indexes.CreateOne(
                new CreateIndexModel<Manager>(Builders<Manager>.IndexKeys.Descending(model => model.userId),
                new CreateIndexOptions { Unique = true })
            );
        }
       
        public List<Manager> Get()
        {
            var managers = _managers.Find(m => m.isActive).ToList();
            return managers;
        }

        public Boolean isValidCredentials(string username, string password)
        {
            Manager manager = _managers.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
            return manager != null;
        }
        
        public Manager Authenticate(string username)
        {
            var manager = _managers.Find<Manager>(manager => manager.username == username).FirstOrDefault();
            return manager;
        }

        public Manager Get(string id)
        {
            var manager = _managers.Find<Manager>(manager => manager.userId == id).FirstOrDefault();
            return manager;
        }
        
        public Manager Create(Manager manager)
        {
            manager.userType = UserType.Admin;
            manager.isActive = true;
            try
            {
                _managers.InsertOne(manager);
            } catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate manager");
                }
            }
            return manager;
        }

        public void UpdatePassword(string id, Manager manager)
        {
            var filter = Builders<Manager>.Filter.Where(_ => _.Id == id);
            var update = Builders<Manager>.Update
                        .Set(_ => _.password, manager.password);
            var options = new FindOneAndUpdateOptions<Manager>();
            _managers.FindOneAndUpdate(filter, update, options);
        }

        public void Delete(string id)
        {
            var filter = Builders<Manager>.Filter.Where(_ => _.userId == id);
            var update = Builders<Manager>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Manager>();
            _managers.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, Manager manager)
        {
            var filter = Builders<Manager>.Filter.Where(_ => _.userId == id);
            var update = Builders<Manager>.Update
                        .Set(_ => _.email, manager.email)
                        .Set(_ => _.phone, manager.phone);
            var options = new FindOneAndUpdateOptions<Manager>();
            _managers.FindOneAndUpdate(filter, update, options);
        }
    }
}
