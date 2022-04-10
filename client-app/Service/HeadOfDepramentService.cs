using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Services
{
    public interface IHeadOfDepramentService
    {
        List<HeadOfDeprament> Get();
        Boolean isValidCredentials(string username, string password);
        Boolean isValidProject(string username, string password);
        HeadOfDeprament Authenticate(string username);
        HeadOfDeprament Get(string id);
        HeadOfDeprament Create(HeadOfDeprament student);
        void UpdatePassword(string id, HeadOfDeprament student);
        void Delete(string id);
        void Update(string id, HeadOfDeprament student);
    }

    public class HeadOfDepramentService : IHeadOfDepramentService
    {
        private readonly IMongoCollection<HeadOfDeprament> _headOfDeprament;

        public HeadOfDepramentService(IHeadOfDepramentDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _headOfDeprament = database.GetCollection<HeadOfDeprament>(settings.HeadOfDepramentCollectionName);
            var x = _headOfDeprament.Indexes;
            _headOfDeprament.Indexes.CreateOne(
                new CreateIndexModel<HeadOfDeprament>(Builders<HeadOfDeprament>.IndexKeys.Descending(model => model.username),
                new CreateIndexOptions { Unique = true })
            );
            _headOfDeprament.Indexes.CreateOne(
                new CreateIndexModel<HeadOfDeprament>(Builders<HeadOfDeprament>.IndexKeys.Descending(model => model.email),
                new CreateIndexOptions { Unique = true })
            );
            _headOfDeprament.Indexes.CreateOne(
                new CreateIndexModel<HeadOfDeprament>(Builders<HeadOfDeprament>.IndexKeys.Descending(model => model.userId),
                new CreateIndexOptions { Unique = true })
            );
        }

        public List<HeadOfDeprament> Get()
        {
            var headOfDeprament = _headOfDeprament.Find(m => m.isActive).ToList();
            return headOfDeprament;
        }

        public Boolean isValidCredentials(string username, string password)
        {
            HeadOfDeprament headOfDeprament = _headOfDeprament.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
            return headOfDeprament != null;
        }

        public Boolean isValidProject(string username, string password)
        {
            HeadOfDeprament headOfDeprament = _headOfDeprament.Find(m => m.password == password && m.username == username && m.isActive == true).FirstOrDefault();
            return headOfDeprament != null;
        }

        public HeadOfDeprament Authenticate(string username)
        {
            var headOfDeprament = _headOfDeprament.Find<HeadOfDeprament>(headOfDeprament => headOfDeprament.username == username).FirstOrDefault();
            return headOfDeprament;
        }

        public HeadOfDeprament Get(string id)
        {
            var headOfDeprament = _headOfDeprament.Find<HeadOfDeprament>(headOfDeprament => headOfDeprament.userId == id).FirstOrDefault();
            return headOfDeprament;
        }

        public HeadOfDeprament Create(HeadOfDeprament headOfDeprament)
        {
            headOfDeprament.userType = UserType.HeadOfDeprament;
            headOfDeprament.isGuid = false;
            headOfDeprament.isActive = true;
            try
            {
                _headOfDeprament.InsertOne(headOfDeprament);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new Exception("duplicate student");
                }
            }
            return headOfDeprament;
        }

        public void UpdatePassword(string id, HeadOfDeprament headOfDeprament)
        {
            var filter = Builders<HeadOfDeprament>.Filter.Where(_ => _.userId == id);
            var update = Builders<HeadOfDeprament>.Update
                        .Set(_ => _.password, headOfDeprament.password);
            var options = new FindOneAndUpdateOptions<HeadOfDeprament>();
            _headOfDeprament.FindOneAndUpdate(filter, update, options);
        }

        public void Delete(string id)
        {
            var filter = Builders<HeadOfDeprament>.Filter.Where(_ => _.userId == id);
            var update = Builders<HeadOfDeprament>.Update
                        .Set(_ => _.isActive, false);
            var options = new FindOneAndUpdateOptions<HeadOfDeprament>();
            _headOfDeprament.FindOneAndUpdate(filter, update, options);
        }

        public void Update(string id, HeadOfDeprament headOfDeprament)
        {
            var filter = Builders<HeadOfDeprament>.Filter.Where(_ => _.userId == id);
            var update = Builders<HeadOfDeprament>.Update
                        .Set(_ => _.email, headOfDeprament.email)
                        .Set(_ => _.phone, headOfDeprament.phone)
                        .Set(_ => _.isGuid, headOfDeprament.isGuid);
            var options = new FindOneAndUpdateOptions<HeadOfDeprament>();
            _headOfDeprament.FindOneAndUpdate(filter, update, options);
        }
    }
}
