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
    public class GuideService
    {
        private readonly IMongoCollection<Guide> _guide;

        public GuideService(IGuideDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _guide = database.GetCollection<Guide>(settings.GuideCollectionName);
            var x = _guide.Indexes;
            _guide.Indexes.CreateOne(
                new CreateIndexModel<Guide>(Builders<Guide>.IndexKeys.Descending(model => model.username),
                new CreateIndexOptions { Unique = true })
            );
            _guide.Indexes.CreateOne(
                new CreateIndexModel<Guide>(Builders<Guide>.IndexKeys.Descending(model => model.email),
                new CreateIndexOptions { Unique = true })
            );
            _guide.Indexes.CreateOne(
                new CreateIndexModel<Guide>(Builders<Guide>.IndexKeys.Descending(model => model.userId),
                new CreateIndexOptions { Unique = true })
            );
        }
        public List<Guide> Get()
        {
            var Guides = _guide.Find(m => m.isActive).ToList();
            return Guides;
        }

        public Boolean isValidCredentials(string username, string password)
        {
            Guide Guide = _guide.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
            return Guide != null;
        }

        public Guide Get(string id)
        {
            var Guide = _guide.Find<Guide>(Guide => Guide.Id == id).FirstOrDefault();
            return Guide;
        }
        public Guide Create(Guide guide)
        {
            guide.isActive = true;
            guide.projects = new List<Project>();
            if (guide.isHeadOfDepratment)
                guide.userType = UserType.HeadOfDeprament;
            else
                guide.userType = UserType.Guid;
            try
            {
                _guide.InsertOne(guide);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate guide");
                }
            }
            return guide;
        }

        public void UpdatePassword(string id, UpdatePassword manager)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.password, manager.password);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }

        internal void Delete(string id)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, UpdateUser manager)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.email, manager.email)
                        .Set(_ => _.name, manager.name)
                        .Set(_ => _.username, manager.username);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }
    }
}
