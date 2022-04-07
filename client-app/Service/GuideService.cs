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
    public interface IGuideService
    {
        List<Guide> Get();
        Boolean isValidCredentials(string username, string password);
        Guide Get(string id);
        Guide GetMyGuide(string id);
        Guide Create(Guide student);
        void UpdatePassword(string id, Guide student);
        void Delete(string id);
        void Update(string id, Guide student);
    }
    public class GuideService : IGuideService
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

        public Guide GetMyGuide(string id)
        {
            var Guide = _guide.Find<Guide>(Guide => Guide.userId == id).FirstOrDefault();
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

        public void UpdatePassword(string id, Guide guide)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.password, guide.password);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }

        public void Delete(string id)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, Guide guide)
        {
            var filter = Builders<Guide>.Filter.Where(_ => _.Id == id);
            var update = Builders<Guide>.Update
                        .Set(_ => _.email, guide.email)
                        .Set(_ => _.phone, guide.phone)
                        .Set(_ => _.isHeadOfDepratment, guide.isHeadOfDepratment);
            var options = new FindOneAndUpdateOptions<Guide>();
            _guide.FindOneAndUpdate(filter, update, options);
        }
    }
}
